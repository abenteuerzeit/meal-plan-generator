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


    // TODO: Doublecheck the id values for corectness
    // https://fdc.nal.usda.gov/fdc-app.html
    public enum ComponentId
    {
        Water = 1051,
        Energy_Atwater_General_Factors_kcal = 2047,
        Energy_Atwater_Specific_Factors_kcal = 2048,
        Energy_kcal = 1008,
        Energy_kJ = 1062,
        Nitrogen_g = 1002,
        Protein_g = 1003,
        Total_lipid_fat_g = 1004,
        Total_fat_NLEA_g = 1085,
        Ash_g = 1007,
        CarbohydrateByDifference_g = 1005,
        CarbohydrateBySummation_g = 1050,
        Fiber_TotalDietary_g = 1079,
        Fiber_Soluble_g = 1082,
        Fiber_Insoluble_g = 1084,
        TotalDietaryFiber_AOAC_2011_25_g = 2033,
        HighMolecularWeightDietaryFiber_g = 2038,
        LowMolecularWeightDietaryFiber_g = 2065,
        Beta_glucan_g = 2058,
        SugarsTotal_g = 1063,
        SugarsTotal_IncludingNLEA_g = 2000,
        Sugars_added_g = 1235,
        Sucrose_g = 1010,
        Glucose_g = 1011,
        Fructose_g = 1012,
        Lactose_g = 1013,
        Maltose_g = 1014,
        Galactose_g = 1075,
        Starch_g = 1009,
        Raffinose_g = 1076,
        Stachyose_g = 1077,
        Verbascose_g = 2063,
        Sorbitol_g = 1056,
        Xylitol_g = 1078,
        Inositol_mg = 1181,
        AceticAcid_mg = 1026,
        CitricAcid_mg = 1032,
        LacticAcid_mg = 1038,
        MalicAcid_mg = 1039,
        OxalicAcid_mg = 1041,
        PyruvicAcid_mg = 1043,
        QuinicAcid_mg = 1044,
        Calcium_mg = 1087,
        Iron_mg = 1089,
        Magnesium_mg = 1090,
        Phosphorus_mg = 1091,
        Potassium_mg = 1092,
        Sodium_mg = 1093,
        Zinc_mg = 1095,
        Copper_mg = 1098,
        Manganese_mg = 1101,
        Selenium_µg = 1103,
        Fluoride_µg = 1099,
        Sulfur_mg = 1094,
        Nickel_µg = 1146,
        Molybdenum_µg = 1102,
        Boron_µg = 1137,
        Vitamin_C_Total_mg = 1162,
        Thiamin_mg = 1165,
        Riboflavin_mg = 1166,
        Niacin_mg = 1167,
        PantothenicAcid_mg = 1170,
        VitaminB6_mg = 1175,
        FolateTotal_µg = 1177,
        FolicAcid_µg = 1186,
        FolateFood_µg = 1187,
        FolateDFE_µg = 1190,
        CholineTotal_mg = 1180,
        CholinFree_mg = 1194,
        CholineFromPhosphocholine_mg = 1195,
        CholineFromPhosphotidylCholine_mg = 1196,
        CholineFromGlycerophosphocholine_mg = 1197,
        Betaine_mg = 1198,
        VitaminB12_µg = 1178,
        VitaminB12Added_µg = 1246,
        VitaminA_RAE_µg = 1106,
        Retinol_µg = 1105,
        CaroteneBeta_µg = 1107,
        CisBetaCarotene_µg = 1159,
        TransBetaCarotene_µg = 2028,
        CryptoxanthinBeta_µg = 1120,
        CryptoxanthinAlpha_µg = 2032,
        VitaminA_IU = 1104,
        Lycopene_µg = 1122,
        Cis_Lycopene_µg = 1160,
        Trans_Lycopene_µg = 2029,
        LuteinAndZeaxanthin_µg = 1123,
        CisLuteinZeaxanthin_µg = 1161,
        Lutein_µg = 1121,
        Zeaxanthin_µg = 1119,
        Phytoene_µg = 1116,
        Phytofluene_µg = 1117,
        VitaminE_mcg_RE = 1158,
        VitaminE_AlphaTocopherol_mg = 1109,
        VitaminE_Added_mg = 1242,
        TocopherolBeta_mg = 1125,
        TocopherolGamma_mg = 1126,
        TocopherolDelta_mg = 1127,
        TocotrienolAlpha_mg = 1128,
        TocotrienolBeta_mg = 1129,
        TocotrienolGamma_mg = 1130,
        TocotrienolDelta_mg = 1131,
        VitaminD_D2andD3_IU = 1110,
        VitaminD_D2andD3_µg = 1114,
        VitaminD2_Ergocalciferol_µg = 1111,
        VitaminD3_Cholecalciferol_µg = 1112,
        TwentyFive_hydroxycholecalciferol_µg = 1113,
        VitaminD4_µg = 2059,
        VitaminK_Phylloquinone_µg = 1185,
        VitaminK_Dihydrophylloquinone_µg = 1184,
        VitaminK_Menaquinone4_µg = 1183,
        FattyAcidsTotalSaturated_g = 1258,
        SFA_4_0_g = 1259,
        SFA_5_0_g = 2003,
        SFA_6_0_g = 1260,
        SFA_7_0_g = 2004,
        SFA_8_0_g = 1261,
        SFA_9_0_g = 2005,
        SFA_10_0_g = 1262,
        SFA_11_0_g = 1335,
        SFA_12_0_g = 1263,
        SFA_13_0_g = 1332,
        SFA_14_0_g = 1264,
        SFA_15_0_g = 1299,
        SFA_16_0_g = 1265,
        SFA_17_0_g = 1300,
        SFA_18_0_g = 1266,
        SFA_20_0_g = 1267,
        SFA_21_0_g = 2006,
        SFA_22_0_g = 1273,
        SFA_23_0_g = 2007,
        SFA_24_0_g = 1301,
        FattyAcids_TotalMonounsaturated_g = 1292,
        MUFA_12_1_g = 2008,
        MUFA_14_1_g = 1274,
        MUFA_14_1c_g = 2009,
        MUFA_15_1_g = 1333,
        MUFA_16_1_g = 1275,
        MUFA_16_1c_g = 1314,
        MUFA_17_1_g = 1323,
        MUFA_17_1_cg = 2010,
        MUFA_18_1_g = 1268,
        MUFA_18_1_cg = 1315,
        MUFA_18_1_11t_18_1tn7_g = 1412,
        MUFA_20_1_g = 1277,
        MUFA_20_1_cg = 2012,
        MUFA_22_1_g = 1279,
        MUFA_22_1_cg = 1317,
        MUFA_22_1_n9_g = 2014,
        MUFA_24_1c_g = 1312,
        FattyAcids_TotalPolyunsaturated_g = 1293,
        PUFA_18_2_g = 1269,
        PUFA_18_2c_g = 2016,
        PUFA_18_2n6cc_g = 1316,
        PUFA_18_2_CLAs_g = 1311,
        PUFA_18_2i_g = 1307,
        PUFA_18_3_g = 1270,
        PUFA_18_3c_g = 2018,
        PUFA_18_3n3ccc_ALA_g = 1404,
        PUFA_18_3n6ccc_g = 1321,
        PUFA_18_3i_g = 1409,
        PUFA_18_4_g = 1276,
        PUFA_20_2c_g = 2026,
        PUFA_20_2_n6cc_g = 1313,
        PUFA_20_3_g = 1325,
        PUFA_20_3c_g = 2020,
        PUFA_20_3n3_g = 1405,
        PUFA_20_4n6_g = 1406,
        PUFA_20_3n9_g = 1414,
        PUFA_22_3_g = 2021,
        PUFA_20_4_g = 1271,
        PUFA_20_4c_g = 2022,
        PUFA_2_4n6_g = 1408,
        PUFA_20_5c_g = 2023,
        PUFA_20_5n3_EPA_g = 1278,
        PUFA_22_2_g = 1334,
        PUFA_21_5_g = 1410,
        PUFA_22_5c_g = 2024,
        PUFA_22_4_g = 1411,
        PUFA_22_5n3_DPA_g = 1280,
        PUFA_22_6c_g = 2025,
        PUFA_22_6n3_DHA_g = 1272,
        TFA_14_1t_g = 1281,
        TFA_16_1t_g = 1303,
        TFA_18_1t_g = 1304,
        TFA_20_1t_g = 2013,
        TFA_22_1t_g = 1305,
        FattyAcids_Total_TransDienoic_g = 1330,
        TFA_18_2_t_NotFurtherDefined_g = 1306,
        TFA_18_2t_g = 2017,
        FattyAcids_Total_TransPolyenoic_g = 1331,
        TFA_18_3t_g = 2019,
        Cholesterol_mg = 1253,
        Phytosterols_mg = 1283,
        Stigmastadiene_mg = 2053,
        Stigmasterol_mg = 1285,
        Campesterol_mg = 1286,
        Brassicasterol_mg = 1287,
        Beta_Sitosterol_mg = 1288,
        Ergosta_7_Enol_mg = 2060,
        Ergosta_7_22_Dienol_mg = 2061,
        Ergosta_5_7_Dienol_mg = 2062,
        Ergosterol_mg = 1284,
        Campestanol_mg = 1289,
        Beta_Sitostanol_mg = 1294,
        Delta_5_Avenasterol_mg = 1296,
        Delta_7_Stigmastenol_mg = 2052,
        Phytosterols_other_mg = 1298,
        Ergothioneine_mg = 2057,
        Tryptophan_g = 1210,
        Threonine_g = 1211,
        Isoleucine_g = 1212,
        Leucine_g = 1213,
        Lysine_g = 1214,
        Methionine_g = 1215,
        Cystine_g = 1216,
        Phenylalanine_g = 1217,
        Tyrosine_g = 1218,
        Valine_g = 1219,
        Arginine_g = 1220,
        Histidine_g = 1221,
        Alanine_g = 1222,
        AsparticAcid_g = 1223,
        GlutamicAcid_g = 1224,
        Glycine_g = 1225,
        Proline_g = 1226,
        Serine_g = 1227,
        Hydroxyproline_g = 1228,
        Cysteine_g = 1232,
        Alcohol_ethyl_g = 1018,
        Daidzein_mg = 1340,
        Genistin_mg = 2050,
        Daidzin_mg = 2049,
        Glycitin_mg = 2051,
        Epigallocatechin_3_Gallate_mg = 1386,
        SpecificGravity = 1024,
        Ribose_g = 1081,
        TotalSugarAlcohols_g = 1086,
        Chlorine_mg = 1088,
        Chromium_µg = 1096,
        Vitamin_E_labelEntryPrimarily_IU = 1124,
        Ten_FormylFolicAcid_10HCOFA_µg = 1191,
        Five_FormyltetrahydrofolicAcid_5HCOH4_µg = 1192,
        PhenolicAcids_Total_mg = 1208,
        Glutamine_g = 1233,
        Taurine_g = 1234,
        Inulin_g = 1403,
        CarbohydratesOther_g = 1072,
    }

}
