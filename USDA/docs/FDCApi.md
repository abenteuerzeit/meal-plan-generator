# IO.Swagger.Api.FDCApi

All URIs are relative to *https://api.nal.usda.gov/fdc*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFood**](FDCApi.md#getfood) | **GET** /v1/food/{fdcId} | Fetches details for one food item by FDC ID
[**GetFoods**](FDCApi.md#getfoods) | **GET** /v1/foods | Fetches details for multiple food items using input FDC IDs
[**GetFoodsList**](FDCApi.md#getfoodslist) | **GET** /v1/foods/list | Returns a paged list of foods, in the &#x27;abridged&#x27; format
[**GetFoodsSearch**](FDCApi.md#getfoodssearch) | **GET** /v1/foods/search | Returns a list of foods that matched search (query) keywords
[**GetJsonSpec**](FDCApi.md#getjsonspec) | **GET** /v1/json-spec | Returns this documentation in JSON format
[**GetYamlSpec**](FDCApi.md#getyamlspec) | **GET** /v1/yaml-spec | Returns this documentation in JSON format
[**PostFoods**](FDCApi.md#postfoods) | **POST** /v1/foods | Fetches details for multiple food items using input FDC IDs
[**PostFoodsList**](FDCApi.md#postfoodslist) | **POST** /v1/foods/list | Returns a paged list of foods, in the &#x27;abridged&#x27; format
[**PostFoodsSearch**](FDCApi.md#postfoodssearch) | **POST** /v1/foods/search | Returns a list of foods that matched search (query) keywords

<a name="getfood"></a>
# **GetFood**
> InlineResponse200 GetFood (string fdcId, string format = null, List<int?> nutrients = null)

Fetches details for one food item by FDC ID

Retrieves a single food item by an FDC ID. Optional format and nutrients can be specified.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetFoodExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();
            var fdcId = fdcId_example;  // string | FDC id of the food to retrieve
            var format = format_example;  // string | Optional. 'abridged' for an abridged set of elements, 'full' for all elements (default). (optional) 
            var nutrients = new List<int?>(); // List<int?> | Optional. List of up to 25 nutrient numbers. Only the nutrient information for the specified nutrients will be returned. Should be comma separated list (e.g. nutrients=203,204) or repeating parameters (e.g. nutrients=203&nutrients=204). If a food does not have any matching nutrients, the food will be returned with an empty foodNutrients element. (optional) 

            try
            {
                // Fetches details for one food item by FDC ID
                InlineResponse200 result = apiInstance.GetFood(fdcId, format, nutrients);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.GetFood: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **fdcId** | **string**| FDC id of the food to retrieve | 
 **format** | **string**| Optional. &#x27;abridged&#x27; for an abridged set of elements, &#x27;full&#x27; for all elements (default). | [optional] 
 **nutrients** | [**List&lt;int?&gt;**](int?.md)| Optional. List of up to 25 nutrient numbers. Only the nutrient information for the specified nutrients will be returned. Should be comma separated list (e.g. nutrients&#x3D;203,204) or repeating parameters (e.g. nutrients&#x3D;203&amp;nutrients&#x3D;204). If a food does not have any matching nutrients, the food will be returned with an empty foodNutrients element. | [optional] 

### Return type

[**InlineResponse200**](InlineResponse200.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getfoods"></a>
# **GetFoods**
> List<Object> GetFoods (List<string> fdcIds, string format = null, List<int?> nutrients = null)

Fetches details for multiple food items using input FDC IDs

Retrieves a list of food items by a list of up to 20 FDC IDs. Optional format and nutrients can be specified. Invalid FDC ID's or ones that are not found are omitted and an empty set is returned if there are no matches.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetFoodsExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();
            var fdcIds = new List<string>(); // List<string> | List of multiple FDC ID's. Should be comma separated list (e.g. fdcIds=534358,373052) or repeating parameters (e.g. fdcIds=534358&fdcIds=373052).
            var format = format_example;  // string | Optional. 'abridged' for an abridged set of elements, 'full' for all elements (default). (optional) 
            var nutrients = new List<int?>(); // List<int?> | Optional. List of up to 25 nutrient numbers. Only the nutrient information for the specified nutrients will be returned. Should be comma separated list (e.g. nutrients=203,204) or repeating parameters (e.g. nutrients=203&nutrients=204). If a food does not have any matching nutrients, the food will be returned with an empty foodNutrients element. (optional) 

            try
            {
                // Fetches details for multiple food items using input FDC IDs
                List&lt;Object&gt; result = apiInstance.GetFoods(fdcIds, format, nutrients);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.GetFoods: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **fdcIds** | [**List&lt;string&gt;**](string.md)| List of multiple FDC ID&#x27;s. Should be comma separated list (e.g. fdcIds&#x3D;534358,373052) or repeating parameters (e.g. fdcIds&#x3D;534358&amp;fdcIds&#x3D;373052). | 
 **format** | **string**| Optional. &#x27;abridged&#x27; for an abridged set of elements, &#x27;full&#x27; for all elements (default). | [optional] 
 **nutrients** | [**List&lt;int?&gt;**](int?.md)| Optional. List of up to 25 nutrient numbers. Only the nutrient information for the specified nutrients will be returned. Should be comma separated list (e.g. nutrients&#x3D;203,204) or repeating parameters (e.g. nutrients&#x3D;203&amp;nutrients&#x3D;204). If a food does not have any matching nutrients, the food will be returned with an empty foodNutrients element. | [optional] 

### Return type

**List<Object>**

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getfoodslist"></a>
# **GetFoodsList**
> List<AbridgedFoodItem> GetFoodsList (List<string> dataType = null, int? pageSize = null, int? pageNumber = null, string sortBy = null, string sortOrder = null)

Returns a paged list of foods, in the 'abridged' format

Retrieves a paged list of foods. Use the pageNumber parameter to page through the entire result set.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetFoodsListExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();
            var dataType = new List<string>(); // List<string> | Optional. Filter on a specific data type; specify one or more values in an array. (optional) 
            var pageSize = 56;  // int? | Optional. Maximum number of results to return for the current page. Default is 50. (optional) 
            var pageNumber = 56;  // int? | Optional. Page number to retrieve. The offset into the overall result set is expressed as (pageNumber * pageSize) (optional) 
            var sortBy = sortBy_example;  // string | Optional. Specify one of the possible values to sort by that field. Note, dataType.keyword will be dataType and lowercaseDescription.keyword will be description in future releases. (optional) 
            var sortOrder = sortOrder_example;  // string | Optional. The sort direction for the results. Only applicable if sortBy is specified. (optional) 

            try
            {
                // Returns a paged list of foods, in the 'abridged' format
                List&lt;AbridgedFoodItem&gt; result = apiInstance.GetFoodsList(dataType, pageSize, pageNumber, sortBy, sortOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.GetFoodsList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **dataType** | [**List&lt;string&gt;**](string.md)| Optional. Filter on a specific data type; specify one or more values in an array. | [optional] 
 **pageSize** | **int?**| Optional. Maximum number of results to return for the current page. Default is 50. | [optional] 
 **pageNumber** | **int?**| Optional. Page number to retrieve. The offset into the overall result set is expressed as (pageNumber * pageSize) | [optional] 
 **sortBy** | **string**| Optional. Specify one of the possible values to sort by that field. Note, dataType.keyword will be dataType and lowercaseDescription.keyword will be description in future releases. | [optional] 
 **sortOrder** | **string**| Optional. The sort direction for the results. Only applicable if sortBy is specified. | [optional] 

### Return type

[**List<AbridgedFoodItem>**](AbridgedFoodItem.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getfoodssearch"></a>
# **GetFoodsSearch**
> SearchResult GetFoodsSearch (string query, List<string> dataType = null, int? pageSize = null, int? pageNumber = null, string sortBy = null, string sortOrder = null, string brandOwner = null)

Returns a list of foods that matched search (query) keywords

Search for foods using keywords. Results can be filtered by dataType and there are options for result page sizes or sorting.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetFoodsSearchExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();
            var query = query_example;  // string | One or more search terms.  The string may include [search operators](https://fdc.nal.usda.gov/help.html#bkmk-2)
            var dataType = new List<string>(); // List<string> | Optional. Filter on a specific data type; specify one or more values in an array. (optional) 
            var pageSize = 56;  // int? | Optional. Maximum number of results to return for the current page. Default is 50. (optional) 
            var pageNumber = 56;  // int? | Optional. Page number to retrieve. The offset into the overall result set is expressed as (pageNumber * pageSize) (optional) 
            var sortBy = sortBy_example;  // string | Optional. Specify one of the possible values to sort by that field. Note, dataType.keyword will be dataType and lowercaseDescription.keyword will be description in future releases. (optional) 
            var sortOrder = sortOrder_example;  // string | Optional. The sort direction for the results. Only applicable if sortBy is specified. (optional) 
            var brandOwner = brandOwner_example;  // string | Optional. Filter results based on the brand owner of the food. Only applies to Branded Foods (optional) 

            try
            {
                // Returns a list of foods that matched search (query) keywords
                SearchResult result = apiInstance.GetFoodsSearch(query, dataType, pageSize, pageNumber, sortBy, sortOrder, brandOwner);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.GetFoodsSearch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **query** | **string**| One or more search terms.  The string may include [search operators](https://fdc.nal.usda.gov/help.html#bkmk-2) | 
 **dataType** | [**List&lt;string&gt;**](string.md)| Optional. Filter on a specific data type; specify one or more values in an array. | [optional] 
 **pageSize** | **int?**| Optional. Maximum number of results to return for the current page. Default is 50. | [optional] 
 **pageNumber** | **int?**| Optional. Page number to retrieve. The offset into the overall result set is expressed as (pageNumber * pageSize) | [optional] 
 **sortBy** | **string**| Optional. Specify one of the possible values to sort by that field. Note, dataType.keyword will be dataType and lowercaseDescription.keyword will be description in future releases. | [optional] 
 **sortOrder** | **string**| Optional. The sort direction for the results. Only applicable if sortBy is specified. | [optional] 
 **brandOwner** | **string**| Optional. Filter results based on the brand owner of the food. Only applies to Branded Foods | [optional] 

### Return type

[**SearchResult**](SearchResult.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getjsonspec"></a>
# **GetJsonSpec**
> void GetJsonSpec ()

Returns this documentation in JSON format

The OpenAPI 3.0 specification for the FDC API rendered as JSON (JavaScript Object Notation)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetJsonSpecExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();

            try
            {
                // Returns this documentation in JSON format
                apiInstance.GetJsonSpec();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.GetJsonSpec: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getyamlspec"></a>
# **GetYamlSpec**
> void GetYamlSpec ()

Returns this documentation in JSON format

The OpenAPI 3.0 specification for the FDC API rendered as YAML (YAML Ain't Markup Language)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetYamlSpecExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();

            try
            {
                // Returns this documentation in JSON format
                apiInstance.GetYamlSpec();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.GetYamlSpec: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="postfoods"></a>
# **PostFoods**
> List<Object> PostFoods (FoodsCriteria body)

Fetches details for multiple food items using input FDC IDs

Retrieves a list of food items by a list of up to 20 FDC IDs. Optional format and nutrients can be specified. Invalid FDC ID's or ones that are not found are omitted and an empty set is returned if there are no matches.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostFoodsExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();
            var body = new FoodsCriteria(); // FoodsCriteria | 

            try
            {
                // Fetches details for multiple food items using input FDC IDs
                List&lt;Object&gt; result = apiInstance.PostFoods(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.PostFoods: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**FoodsCriteria**](FoodsCriteria.md)|  | 

### Return type

**List<Object>**

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="postfoodslist"></a>
# **PostFoodsList**
> List<AbridgedFoodItem> PostFoodsList (FoodListCriteria body)

Returns a paged list of foods, in the 'abridged' format

Retrieves a paged list of foods. Use the pageNumber parameter to page through the entire result set.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostFoodsListExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();
            var body = new FoodListCriteria(); // FoodListCriteria | 

            try
            {
                // Returns a paged list of foods, in the 'abridged' format
                List&lt;AbridgedFoodItem&gt; result = apiInstance.PostFoodsList(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.PostFoodsList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**FoodListCriteria**](FoodListCriteria.md)|  | 

### Return type

[**List<AbridgedFoodItem>**](AbridgedFoodItem.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="postfoodssearch"></a>
# **PostFoodsSearch**
> SearchResult PostFoodsSearch (FoodSearchCriteria body)

Returns a list of foods that matched search (query) keywords

Search for foods using keywords. Results can be filtered by dataType and there are options for result page sizes or sorting.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostFoodsSearchExample
    {
        public void main()
        {
            // Configure API key authorization: ApiKeyAuth
            Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("api_key", "Bearer");

            var apiInstance = new FDCApi();
            var body = new FoodSearchCriteria(); // FoodSearchCriteria | The query string may also include standard [search operators](https://fdc.nal.usda.gov/help.html#bkmk-2)

            try
            {
                // Returns a list of foods that matched search (query) keywords
                SearchResult result = apiInstance.PostFoodsSearch(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling FDCApi.PostFoodsSearch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**FoodSearchCriteria**](FoodSearchCriteria.md)| The query string may also include standard [search operators](https://fdc.nal.usda.gov/help.html#bkmk-2) | 

### Return type

[**SearchResult**](SearchResult.md)

### Authorization

[ApiKeyAuth](../README.md#ApiKeyAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
