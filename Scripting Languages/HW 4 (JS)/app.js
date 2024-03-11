const firstNameInput = document.getElementById("FirstNameInput");

const lastNameInput = document.getElementById("LastNameInput");

const thankYouMessage = document.getElementById("ThankYouMessage");

const nameForm = document.getElementById("NameForm");

nameForm.addEventListener("submit", (e) => {
	e.preventDefault();
  thankYouMessage.textContent = `Thank you for your submission ${firstNameInput.value} ${lastNameInput.value}`;
});

const w3rLink = document.getElementById("w3r");

const attributeResult = document.getElementById("AttributeResult");

const attributeButton = document.getElementById("AttributeButton");

const getAttributes = () => {
attributeResult.textContent = `href: ${w3rLink.href},  hreflang: ${w3rLink.hreflang}, rel: ${w3rLink.rel}, target: ${w3rLink.target}, type: ${w3rLink.type}`
};

attributeButton.addEventListener("click", getAttributes);

const table = document.getElementById("Table");

const tableButton = document.getElementById("TableButton");

const addRow = () => {
const newRow = table.insertRow(0);
newRow.innerHTML = "Row";
};

tableButton.addEventListener("click", addRow);
