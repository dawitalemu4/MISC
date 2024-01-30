const nameButton = document.getElementById("NameButton");

const formContainer = document.getElementById("FormContainer");

const nameInput = document.getElementById("NameInput");

const submitButton = document.getElementById("SubmitButton");

const handleNameButtonClick = () => {
    nameButton.classList.add("slideUp");
    formContainer.style.display = "flex";
};

nameButton.addEventListener("click", handleNameButtonClick);

const handleSubmitButtonClick = () => {
    event.preventDefault();
    nameButton.innerText = nameInput.value;
    formContainer.style.display = "none";
    nameButton.classList.remove("slideUp");
};

formContainer.addEventListener("submit", handleSubmitButtonClick);