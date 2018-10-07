# AdventureWorksLT.Service.Api.ProductsApi

All URIs are relative to *http://localhost:9000*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ProductsGet**](ProductsApi.md#productsget) | **GET** /api/Products | 


<a name="productsget"></a>
# **ProductsGet**
> List<Product> ProductsGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using AdventureWorksLT.Service.Api;
using AdventureWorksLT.Service.Client;
using AdventureWorksLT.Service.Model;

namespace Example
{
    public class ProductsGetExample
    {
        public void main()
        {
            var apiInstance = new ProductsApi();

            try
            {
                List&lt;Product&gt; result = apiInstance.ProductsGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProductsApi.ProductsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Product>**](Product.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

