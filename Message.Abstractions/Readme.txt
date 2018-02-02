To store configuration for a service a POST request needs to be sent to configuration service

E.g. below
POST http://10.10.1.201:7001/rs_message

POST Body
{
    "AllowedRoles": [
        "UBSPortal",
        "AnotherRole"
    ]
}

Notes: The Bearer token would determine the tenant against which the configuration will be stored. Configuration service stores it in Redis