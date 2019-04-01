Backend

	Please don't miss any of the following points:
	  - Build the Backend project to load the nuget packeages
	  - Open sql server and run Database Script.sql to create the database  (don't forget to change the file path at the script at your machine)
	  - Change the connection strings at Web.config located in the following projects
              * Backend\DataAccess\Web.config
              * Backend\DocumentManagementAPIs\Web.config
              * Backend\DataAccess.Tests\App.config

          - Change the appsetting value of the key =>["LocalDirectory"] at Web.config located in "Backend\DocumentManagementAPIs\Web.config" with local directory at your machine

	  - NInject classes registeration located at Backend\Services\App_Start\Ninject.Web.Common.cs	



Frontend
	Please don't miss any of the following points:
	 - open the cmd then write the fillowing commands 
		* npm install           [to download the packages]
		* npm start             [to run the project]
		* npm run test:watch    [to run the test cases]
		
To login use the below credintials as admin user role
         - username = TEST@TEST.TEST
	 - password = Samplestring_2
