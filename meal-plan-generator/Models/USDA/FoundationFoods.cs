using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace meal_plan_generator.Models.USDA
{
    public class FoodCategory
    {
        public FoodCategory(
            string description,
            int? id,
            string code
        )
        {
            this.Description = description;
            this.Id = id;
            this.Code = code;
        }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id { get; }

        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string Code { get; }
    }

    public class FoodNutrient
    {
        public FoodNutrient(
            string type,
            int? id,
            Nutrient nutrient,
            int? dataPoints,
            FoodNutrientDerivation foodNutrientDerivation,
            double? median,
            double? amount,
            double? max,
            double? min
        )
        {
            this.Type = type;
            this.Id = id;
            this.Nutrient = nutrient;
            this.DataPoints = dataPoints;
            this.FoodNutrientDerivation = foodNutrientDerivation;
            this.Median = median;
            this.Amount = amount;
            this.Max = max;
            this.Min = min;
        }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id { get; }

        [JsonProperty("nutrient")]
        [JsonPropertyName("nutrient")]
        public Nutrient Nutrient { get; }

        [JsonProperty("dataPoints")]
        [JsonPropertyName("dataPoints")]
        public int? DataPoints { get; }

        [JsonProperty("foodNutrientDerivation")]
        [JsonPropertyName("foodNutrientDerivation")]
        public FoodNutrientDerivation FoodNutrientDerivation { get; }

        [JsonProperty("median")]
        [JsonPropertyName("median")]
        public double? Median { get; }

        [JsonProperty("amount")]
        [JsonPropertyName("amount")]
        public double? Amount { get; }

        [JsonProperty("max")]
        [JsonPropertyName("max")]
        public double? Max { get; }

        [JsonProperty("min")]
        [JsonPropertyName("min")]
        public double? Min { get; }
    }

    public class FoodNutrientDerivation
    {
        public FoodNutrientDerivation(
            string code,
            string description,
            FoodNutrientSource foodNutrientSource
        )
        {
            this.Code = code;
            this.Description = description;
            this.FoodNutrientSource = foodNutrientSource;
        }

        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string Code { get; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonProperty("foodNutrientSource")]
        [JsonPropertyName("foodNutrientSource")]
        public FoodNutrientSource FoodNutrientSource { get; }
    }

    public class FoodNutrientSource
    {
        public FoodNutrientSource(
            int? id,
            string code,
            string description
        )
        {
            this.Id = id;
            this.Code = code;
            this.Description = description;
        }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id { get; }

        [JsonProperty("code")]
        [JsonPropertyName("code")]
        public string Code { get; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; }
    }

    public class FoodPortion
    {
        public FoodPortion(
            int? id,
            double? value,
            MeasureUnit measureUnit,
            string modifier,
            double? gramWeight,
            int? sequenceNumber,
            int? minYearAcquired,
            double? amount,
            string portionDescription
        )
        {
            this.Id = id;
            this.Value = value;
            this.MeasureUnit = measureUnit;
            this.Modifier = modifier;
            this.GramWeight = gramWeight;
            this.SequenceNumber = sequenceNumber;
            this.MinYearAcquired = minYearAcquired;
            this.Amount = amount;
            this.PortionDescription = portionDescription;
        }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id { get; }

        [JsonProperty("value")]
        [JsonPropertyName("value")]
        public double? Value { get; }

        [JsonProperty("measureUnit")]
        [JsonPropertyName("measureUnit")]
        public MeasureUnit MeasureUnit { get; }

        [JsonProperty("modifier")]
        [JsonPropertyName("modifier")]
        public string Modifier { get; }

        [JsonProperty("gramWeight")]
        [JsonPropertyName("gramWeight")]
        public double? GramWeight { get; }

        [JsonProperty("sequenceNumber")]
        [JsonPropertyName("sequenceNumber")]
        public int? SequenceNumber { get; }

        [JsonProperty("minYearAcquired")]
        [JsonPropertyName("minYearAcquired")]
        public int? MinYearAcquired { get; }

        [JsonProperty("amount")]
        [JsonPropertyName("amount")]
        public double? Amount { get; }

        [JsonProperty("portionDescription")]
        [JsonPropertyName("portionDescription")]
        public string PortionDescription { get; }
    }

    public class FoundationFood
    {
        public FoundationFood(
            string foodClass,
            string description,
            List<FoodNutrient> foodNutrients,
            List<object> foodAttributes,
            List<NutrientConversionFactor> nutrientConversionFactors,
            bool? isHistoricalReference,
            int? ndbNumber,
            int? fdcId,
            string dataType,
            FoodCategory foodCategory,
            List<InputFood> inputFoods,
            List<FoodPortion> foodPortions,
            string publicationDate,
            string scientificName
        )
        {
            this.FoodClass = foodClass;
            this.Description = description;
            this.FoodNutrients = foodNutrients;
            this.FoodAttributes = foodAttributes;
            this.NutrientConversionFactors = nutrientConversionFactors;
            this.IsHistoricalReference = isHistoricalReference;
            this.NdbNumber = ndbNumber;
            this.FdcId = fdcId;
            this.DataType = dataType;
            this.FoodCategory = foodCategory;
            this.InputFoods = inputFoods;
            this.FoodPortions = foodPortions;
            this.PublicationDate = publicationDate;
            this.ScientificName = scientificName;
        }

        [JsonProperty("foodClass")]
        [JsonPropertyName("foodClass")]
        public string FoodClass { get; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonProperty("foodNutrients")]
        [JsonPropertyName("foodNutrients")]
        public IReadOnlyList<FoodNutrient> FoodNutrients { get; }

        [JsonProperty("foodAttributes")]
        [JsonPropertyName("foodAttributes")]
        public IReadOnlyList<object> FoodAttributes { get; }

        [JsonProperty("nutrientConversionFactors")]
        [JsonPropertyName("nutrientConversionFactors")]
        public IReadOnlyList<NutrientConversionFactor> NutrientConversionFactors { get; }

        [JsonProperty("isHistoricalReference")]
        [JsonPropertyName("isHistoricalReference")]
        public bool? IsHistoricalReference { get; }

        [JsonProperty("ndbNumber")]
        [JsonPropertyName("ndbNumber")]
        public int? NdbNumber { get; }

        [JsonProperty("fdcId")]
        [JsonPropertyName("fdcId")]
        public int? FdcId { get; }

        [JsonProperty("dataType")]
        [JsonPropertyName("dataType")]
        public string DataType { get; }

        [JsonProperty("foodCategory")]
        [JsonPropertyName("foodCategory")]
        public FoodCategory FoodCategory { get; }

        [JsonProperty("inputFoods")]
        [JsonPropertyName("inputFoods")]
        public IReadOnlyList<InputFood> InputFoods { get; }

        [JsonProperty("foodPortions")]
        [JsonPropertyName("foodPortions")]
        public IReadOnlyList<FoodPortion> FoodPortions { get; }

        [JsonProperty("publicationDate")]
        [JsonPropertyName("publicationDate")]
        public string PublicationDate { get; }

        [JsonProperty("scientificName")]
        [JsonPropertyName("scientificName")]
        public string ScientificName { get; }
    }

    public class InputFood
    {
        public InputFood(
            int? id,
            string foodDescription,
            InputFood inputFood
        )
        {
            this.Id = id;
            this.FoodDescription = foodDescription;
            this.InputFood1 = inputFood;
        }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id { get; }

        [JsonProperty("foodDescription")]
        [JsonPropertyName("foodDescription")]
        public string FoodDescription { get; }

        [JsonProperty("inputFood")]
        [JsonPropertyName("inputFood")]
        public InputFood InputFood1 { get; }
    }

    public class InputFood2
    {
        public InputFood2(
            string foodClass,
            string description,
            int? fdcId,
            string dataType,
            FoodCategory foodCategory,
            string publicationDate
        )
        {
            this.FoodClass = foodClass;
            this.Description = description;
            this.FdcId = fdcId;
            this.DataType = dataType;
            this.FoodCategory = foodCategory;
            this.PublicationDate = publicationDate;
        }

        [JsonProperty("foodClass")]
        [JsonPropertyName("foodClass")]
        public string FoodClass { get; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonProperty("fdcId")]
        [JsonPropertyName("fdcId")]
        public int? FdcId { get; }

        [JsonProperty("dataType")]
        [JsonPropertyName("dataType")]
        public string DataType { get; }

        [JsonProperty("foodCategory")]
        [JsonPropertyName("foodCategory")]
        public FoodCategory FoodCategory { get; }

        [JsonProperty("publicationDate")]
        [JsonPropertyName("publicationDate")]
        public string PublicationDate { get; }
    }

    public class MeasureUnit
    {
        public MeasureUnit(
            int? id,
            string name,
            string abbreviation
        )
        {
            this.Id = id;
            this.Name = name;
            this.Abbreviation = abbreviation;
        }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id { get; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonProperty("abbreviation")]
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; }
    }

    public class Nutrient
    {
        public Nutrient(
            int? id,
            string number,
            string name,
            int? rank,
            string unitName
        )
        {
            this.Id = id;
            this.Number = number;
            this.Name = name;
            this.Rank = rank;
            this.UnitName = unitName;
        }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int? Id { get; }

        [JsonProperty("number")]
        [JsonPropertyName("number")]
        public string Number { get; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonProperty("rank")]
        [JsonPropertyName("rank")]
        public int? Rank { get; }

        [JsonProperty("unitName")]
        [JsonPropertyName("unitName")]
        public string UnitName { get; }
    }

    public class NutrientConversionFactor
    {
        public NutrientConversionFactor(
            string type,
            double? proteinValue,
            double? fatValue,
            double? carbohydrateValue,
            double? value
        )
        {
            this.Type = type;
            this.ProteinValue = proteinValue;
            this.FatValue = fatValue;
            this.CarbohydrateValue = carbohydrateValue;
            this.Value = value;
        }

        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonProperty("proteinValue")]
        [JsonPropertyName("proteinValue")]
        public double? ProteinValue { get; }

        [JsonProperty("fatValue")]
        [JsonPropertyName("fatValue")]
        public double? FatValue { get; }

        [JsonProperty("carbohydrateValue")]
        [JsonPropertyName("carbohydrateValue")]
        public double? CarbohydrateValue { get; }

        [JsonProperty("value")]
        [JsonPropertyName("value")]
        public double? Value { get; }
    }

    public class Root
    {
        public Root(
            List<FoundationFood> foundationFoods
        )
        {
            this.FoundationFoods = foundationFoods;
        }

        [JsonProperty("FoundationFoods")]
        [JsonPropertyName("FoundationFoods")]
        public IReadOnlyList<FoundationFood> FoundationFoods { get; }
    }


}
