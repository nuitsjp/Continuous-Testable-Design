# AdventureWorksLT.Service.Api.SalesOrderDetailsApi

All URIs are relative to *http://localhost:9000*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SalesOrderDetailsGet**](SalesOrderDetailsApi.md#salesorderdetailsget) | **GET** /api/SalesOrderDetails | 


<a name="salesorderdetailsget"></a>
# **SalesOrderDetailsGet**
> List<SalesOrderDetail> SalesOrderDetailsGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using AdventureWorksLT.Service.Api;
using AdventureWorksLT.Service.Client;
using AdventureWorksLT.Service.Model;

namespace Example
{
    public class SalesOrderDetailsGetExample
    {
        public void main()
        {
            var apiInstance = new SalesOrderDetailsApi();

            try
            {
                List&lt;SalesOrderDetail&gt; result = apiInstance.SalesOrderDetailsGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SalesOrderDetailsApi.SalesOrderDetailsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<SalesOrderDetail>**](SalesOrderDetail.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

