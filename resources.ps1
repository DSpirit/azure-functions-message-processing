[CmdletBinding()]
param (
    [Parameter()]
    [string] $rg,
    [Parameter()]
    [string] $sbNamespace
    
)

# ARM Deployment
#az deployment group create -n servicebus-template -f ./Templates/servicebus.json -g $rg --parameters serviceBusNamespace='$sbNamespace'

# CLI
az servicebus queue create -g $rg --namespace-name $sbNamespace -n q.orders.sap
az servicebus queue create -g $rg --namespace-name $sbNamespace -n q.orders.crm
az servicebus topic create -g $rg --namespace-name $sbNamespace -n orders
az servicebus topic subscription create -g $rg --namespace-name $sbNamespace --topic-name orders -n sap
az servicebus topic subscription create -g $rg --namespace-name $sbNamespace --topic-name orders -n crm