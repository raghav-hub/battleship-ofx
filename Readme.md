# Battleship API

This is a simple restful API for implementing the Battleship game, rules are listed in the [rules](OFX_Coding_Exercise2020.pdf)

## Build/Test
compile: `dotnet build`

run tests: `dotnet test`

## Application Deployment

### Setup AWS on dev machine:
- install aws cli (ref: https://docs.aws.amazon.com/cli/latest/userguide/cli-chap-install.html)
- configure cli with the profile ofx-battleship (or your preferable profile name) (ref: https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-quickstart.html)
  (update the preferred profile name in aws-lambda-tools-defaults.json file)

### Deployment (ref: https://docs.amazonaws.cn/en_us/toolkit-for-visual-studio/latest/user-guide/lambda-cli-publish.html)
- Setup the amazon toolKit for Visual Studio (ref: https://docs.amazonaws.cn/en_us/toolkit-for-visual-studio/latest/user-guide/setup.html#install)
- install Amazon.Lambda.Tools as a global tool, cmd to run: `dotnet tool install -g Amazon.Lambda.Tools`
- dotnet lambda --help will list out the helpful commands
- dotnet lambda deploy-serverless --stack-name battleship-challenge-app --profile ofx-battleship --s3-bucket battleship-challenge-application
- command above should deploy the application template serverless.template which includes an api gateway pointing to the lambda as an endpoint having the application code
 ![](./screenshots/deployment.PNG "deployment execution")
- url to test https://aypg2ezaoe.execute-api.ap-southeast-2.amazonaws.com/Prod/api/values


### Assumptions made:
- as there is no persistance needed, using an im-memory allocation for storing the state of a game
- if persistance exists, there would be a three tier design with BattleshipChallenge.Data project managing the repository layer

