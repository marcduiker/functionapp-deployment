# Function App Deployment

This is a sample repository to demonstrate how a Function App can be deployed to Azure using GitHub Actions.

The [`infrastructure.yml`](.github/workflows/infrastructure.yml) workflow creates/updates the Azure resources.

The [`application.yml`](.github/workflows/application.yml) workflow packages and deploys the Function App project.

This repo and it's files are used in the [**Azure Functions University** *Deployment lesson*](https://github.com/marcduiker/azure-functions-university/blob/main/lessons/deployment.md).

## Status

![infrastructure](https://github.com/marcduiker/functionapp-deployment/workflows/infrastructure/badge.svg)

![application](https://github.com/marcduiker/functionapp-deployment/workflows/application/badge.svg)