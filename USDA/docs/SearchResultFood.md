# IO.Swagger.Model.SearchResultFood
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**FdcId** | **int?** | Unique ID of the food. | 
**DataType** | **string** | The type of the food data. | [optional] 
**Description** | **string** | The description of the food. | 
**FoodCode** | **string** | Any A unique ID identifying the food within FNDDS. | [optional] 
**FoodNutrients** | [**List&lt;AbridgedFoodNutrient&gt;**](AbridgedFoodNutrient.md) |  | [optional] 
**PublicationDate** | **string** | Date the item was published to FDC. | [optional] 
**ScientificName** | **string** | The scientific name of the food. | [optional] 
**BrandOwner** | **string** | Brand owner for the food. Only applies to Branded Foods. | [optional] 
**GtinUpc** | **string** | GTIN or UPC code identifying the food. Only applies to Branded Foods. | [optional] 
**Ingredients** | **string** | The list of ingredients (as it appears on the product label). Only applies to Branded Foods. | [optional] 
**NdbNumber** | **int?** | Unique number assigned for foundation foods. Only applies to Foundation and SRLegacy Foods. | [optional] 
**AdditionalDescriptions** | **string** | Any additional descriptions of the food. | [optional] 
**AllHighlightFields** | **string** | allHighlightFields | [optional] 
**Score** | **float?** | Relative score indicating how well the food matches the search criteria. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

