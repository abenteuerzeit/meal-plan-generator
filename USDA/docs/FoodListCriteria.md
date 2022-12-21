# IO.Swagger.Model.FoodListCriteria
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DataType** | **List&lt;string&gt;** | Optional. Filter on a specific data type; specify one or more values in an array. | [optional] 
**PageSize** | **int?** | Optional. Maximum number of results to return for the current page. Default is 50. | [optional] 
**PageNumber** | **int?** | Optional. Page number to retrieve. The offset into the overall result set is expressed as (pageNumber * pageSize) | [optional] 
**SortBy** | **string** | Optional. Specify one of the possible values to sort by that field. Note, dataType.keyword will be dataType and lowercaseDescription.keyword will be description in future releases. | [optional] 
**SortOrder** | **string** | Optional. The sort direction for the results. Only applicable if sortBy is specified. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

