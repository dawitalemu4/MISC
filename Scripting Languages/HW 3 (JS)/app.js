const temp = Math.random();
const tempForm = document.getElementById("CustomTempForm");
const customTemp = document.getElementById("CustomTemp");
const c = document.getElementById("C");
const f = document.getElementById("F");
const response = document.getElementById("Response");

const convertToF = (temp) => {
    return ((temp*9)/5)+32;
};

const convertToC = (temp) => {
    return ((temp-32)*5)/9;
};

const updateTemp = (temp) => {
    c.innerText = temp;
    f.innerText = convertToF(temp);
    response.innerText = `It is ${convertToF(temp)}°F today. That's ${temp}°C.`;
};

tempForm.addEventListener("submit", (e) => {
    e.preventDefault();
    updateTemp(parseFloat(customTemp.value))
});

updateTemp(temp);