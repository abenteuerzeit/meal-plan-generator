/* 
 * Food Data Central API
 *
 * The FoodData Central API provides REST access to FoodData Central (FDC). It is intended primarily to assist application developers wishing to incorporate nutrient data into their applications or websites.   To take full advantage of the API, developers should familiarize themselves with the database by reading the database documentation available via links on [Data Type Documentation](https://fdc.nal.usda.gov/data-documentation.html). This documentation provides the detailed definitions and descriptions needed to understand the data elements referenced in the API documentation.      Additional details about the API including rate limits, access, and licensing are available on the [FDC website](https://fdc.nal.usda.gov/api-guide.html)
 *
 * OpenAPI spec version: 1.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// applies to Foundation foods. Not all inputFoods will have all fields.
    /// </summary>
    [DataContract]
        public partial class InputFoodFoundation :  IEquatable<InputFoodFoundation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputFoodFoundation" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="foodDescription">foodDescription.</param>
        /// <param name="inputFood">inputFood.</param>
        public InputFoodFoundation(int? id = default(int?), string foodDescription = default(string), SampleFoodItem inputFood = default(SampleFoodItem))
        {
            this.Id = id;
            this.FoodDescription = foodDescription;
            this.InputFood = inputFood;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets FoodDescription
        /// </summary>
        [DataMember(Name="foodDescription", EmitDefaultValue=false)]
        public string FoodDescription { get; set; }

        /// <summary>
        /// Gets or Sets InputFood
        /// </summary>
        [DataMember(Name="inputFood", EmitDefaultValue=false)]
        public SampleFoodItem InputFood { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InputFoodFoundation {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FoodDescription: ").Append(FoodDescription).Append("\n");
            sb.Append("  InputFood: ").Append(InputFood).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as InputFoodFoundation);
        }

        /// <summary>
        /// Returns true if InputFoodFoundation instances are equal
        /// </summary>
        /// <param name="input">Instance of InputFoodFoundation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InputFoodFoundation input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.FoodDescription == input.FoodDescription ||
                    (this.FoodDescription != null &&
                    this.FoodDescription.Equals(input.FoodDescription))
                ) && 
                (
                    this.InputFood == input.InputFood ||
                    (this.InputFood != null &&
                    this.InputFood.Equals(input.InputFood))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.FoodDescription != null)
                    hashCode = hashCode * 59 + this.FoodDescription.GetHashCode();
                if (this.InputFood != null)
                    hashCode = hashCode * 59 + this.InputFood.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
