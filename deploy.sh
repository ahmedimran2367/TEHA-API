#/bin/bash
export PROJECT_NAME=TEHA.Portal/TEHA.Portal/TEHA.Portal.API
export Solution=Waste.ClientIdentity
export PublishFolder=./$PROJECT_NAME/publish

#Dotnet Publish to create the exploded distribution folder
dotnet publish $PROJECT_NAME -c Release -o publish

#change to publish folder to start the zip build process
cd $PublishFolder

#Zip the solution into .zip file to be utilized later for deployment
zip -r deployment.zip .

#move newly created deployment.zip to parent folder above PublishFolder directory structure
mv deployment.zip ../../

# change to parent folder above PublishFolder directory structure
cd ../../

    # Reading secure environment specifc variable from Bitbucket Repo Vars - client_service_principal_UID/PWD/TENTANTID 
	SP_UID="${environment^^}_SP_UID"
	SP_TENTID="${environment^^}_SP_TENTID"
	SP_PWD="${environment^^}_SP_PWD"
	
    echo "*****************************Login AZURE***************$******************************"
    #loging in into azure using the waste-deploy-dev service principal	
	az login --service-principal -u ${!SP_UID} -p ${!SP_PWD} --tenant ${!SP_TENTID}

    echo "***************************START FOR CLIENT*******$clientname******************************************"
	#Read the file with the target server where to deploy the code 
	source ./config/$environment/target_server.config

	#Possibility of having multiple target for same environment
	IFS=',' read -r -a arrayTargetServer <<< "$target_server"

	#Loop through the array of target server names
	for targetServerName in "${arrayTargetServer[@]}"
	do
		echo "*****START*******SUBSCRIPTION***$subscription**********RESOURCE GROUP***$resource_group************TARGET SERVER***$targetServerName**************"
		# Deploy .zip file with azure cli through push deployment
	    az webapp deployment source config-zip	--subscription $subscription --resource-group $resource_group --name $targetServerName --src ./deployment.zip

		echo "*****END*******SUBSCRIPTION***$subscription**********RESOURCE GROUP***$resource_group************TARGET SERVER***$targetServerName**************"
	done
