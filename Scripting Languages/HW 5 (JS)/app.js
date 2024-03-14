const cylinder = {
    radius: Math.random(),
    height: Math.random(),
};

const cylinderForm = document.getElementById("CustomCylinderForm");

const customRadius = document.getElementById("CustomRadius");

const customHeight = document.getElementById("CustomHeight");

const volumeText = document.getElementById("VolumeText");

const getVolume = (radius, height) => {
  return 3.14 * (radius*radius) * height;
};

const updateVolumeText = (volume) => {
  volumeText.innerText = `The volume of the cylinder is ${volume}.`;
};

cylinderForm.addEventListener("submit", (e) => {
  e.preventDefault();
  const newRadius = parseFloat(customRadius.value);
  const newHeight = parseFloat(customHeight.value);
  updateVolumeText(getVolume(newRadius, newHeight))
});

var library = [
{ title: 'The Road Ahead', author: 'Bill Gates', readingStatus: true },
{ title: 'Water Isaacson', author: 'Steve Jobs', readingStatus: true },
{ title: 'Mockingjay: The Final Book of The Hunger Games', author: 'Suzanne Collins', readingStatus: false }
]; 

const table = document.getElementById("Table");

library.map((book) => {
const newRow = table.insertRow(-1);
const titleCell = newRow.insertCell(0);
const authorCell = newRow.insertCell(1);
const statusCell = newRow.insertCell(2);
titleCell.innerHTML = `${book.title}`;
authorCell.innerHTML = `${book.author}`;
statusCell.innerHTML = `${book.readingStatus}`;
});

var a = document.createElement('a');

const urlForm = document.getElementById("URLParseForm");

const urlInput = document.getElementById("URLInput");

const urlText = document.getElementById("URLProps");

const parseURL = (e) => {
e.preventDefault();
a.href = urlInput.value;
urlText.innerHTML = `Protocol: ${a.protocol}, Host Name: ${a.hostname}, Port: ${a.port}, Query: ${a.search.slice(1)}`
}

urlForm.addEventListener("submit", parseURL);
