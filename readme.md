# Azure Functions Template

This repository shows an example setup of queueing and processing messages in Azure Functions.
> Azure Functions: v3

> Framework: .NET Core 3.1

Functions:
- `Mock/Mock.cs`: Acts like the target
- `Order/DistributeOrder.{Target}.cs`: Checks if the message should get pushed to the backend.
- `Order/PushOrder.{Target}.cs`: Sends out the message via POST HTTP request.
- `Template/servicebus.json`: ServiceBus components (alternatively you could use the `resources.ps1`)
- `resources.ps1`: Creates all necessary components
- `run.http`: Simulate request chain for sample targets "SAP" and "CRM"
- `Run.cs`: Queue message

## Setup
### Prerequisites
- Azure Subscription
- Azure ServiceBus (at least Standard tier)
- .NET Core 3.1
- Visual Studio Code
- Run `code --install-extension humao.rest-client` to install the REST Client for testing reasons

### Execute
1. Run `az login`.
1. Run `resources.ps1` and provide your resource group name as well as the ServiceBus namespace name.
1. Run `func start`.
1. Open `run.http` and send one of the requests via REST Client by clicking the "Send Request" button.