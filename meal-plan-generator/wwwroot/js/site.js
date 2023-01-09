// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function setFormRandomValues() {
    // Generate a random date between 1900 and today
    const min = new Date(1900, 0, 1).getTime();
    const max = new Date().getTime();
    const randomTimestamp = Math.floor(Math.random() * (max - min)) + min;
    const randomDate = new Date(randomTimestamp);
    const formattedRandomDate = randomDate.toISOString().slice(0, 10);

    // Set the random date as the value of the birthdate input
    const birthdateInput = document.getElementById("birthdate");
    birthdateInput.value = formattedRandomDate;

    // Select a random option from the gender select element
    const genderSelect = document.getElementById("gender");
    const randomIndex = Math.floor(Math.random() * genderSelect.options.length);
    genderSelect.options[randomIndex].selected = true;

    // Set random values for the nutrient data inputs
    const nutrientDataInputs = document.querySelectorAll(".form__input");
    nutrientDataInputs.forEach(input => {
        const randomValue = Math.random() * 100;
        input.value = randomValue;
    });
}




function calculateAge(birthday) {
    var ageDifMs = Date.now() - birthday.getTime();
    var ageDate = new Date(ageDifMs);
    return Math.abs(ageDate.getUTCFullYear() - 1970);
}


document.getElementById('meal-plan-form').addEventListener('submit', function (event) {
    event.preventDefault();

    // Calculate the age of the user based on their birthdate
    var birthdate = new Date(document.getElementById('birthdate').value);
    var age = calculateAge(birthdate);

    // Set the values in the form based on the age of the user
    // ...
});



function fillForm() {
    // Generate random values for the form fields
    const servingSize = Math.floor(Math.random() * 1000);
    const calories = Math.floor(Math.random() * 3000);
    const protein = Math.floor(Math.random() * 100);
    const carbohydrates = Math.floor(Math.random() * 100);
    const fat = Math.floor(Math.random() * 100);
    const fiber = Math.floor(Math.random() * 100);
    const sugar = Math.floor(Math.random() * 100);
    const vitaminA = Math.floor(Math.random() * 100);
    const vitaminC = Math.floor(Math.random() * 100);
    const calcium = Math.floor(Math.random() * 100);
    const iron = Math.floor(Math.random() * 100);

    // Set the values of the form fields
    document.getElementById("servingSize").value = servingSize;
    document.getElementById("calories").value = calories;
    document.getElementById("protein").value = protein;
    document.getElementById("carbohydrates").value = carbohydrates;
    document.getElementById("fat").value = fat;
    document.getElementById("fiber").value = fiber;
    document.getElementById("sugar").value = sugar;
    document.getElementById("vitaminA").value = vitaminA;
    document.getElementById("vitaminC").value = vitaminC;
    document.getElementById("calcium").value = calcium;
    document.getElementById("iron").value = iron;
}
