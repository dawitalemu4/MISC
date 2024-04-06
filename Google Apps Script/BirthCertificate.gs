function BaptismCertificate() {

    // initialize new array to hold all values of what the user submits in the google form, each index will correspond with the order of the questions in the form
    const responses = [];

    const ethiopianMonths = {
        "01": "መስከረም",
        "02": "ጥቅምት",
        "03": "ኅዳር",
        "04": "ታኅሣሥ",
        "05": "ጥር",
        "06": "የካቲት",
        "07": "መጋቢት",
        "08": "ሚያዝያ",
        "09": "ግንቦት",
        "10": "ሰኔ",
        "11": "ሐምሌ",
        "12": "ነሐሴ",
        "13": "ጳጉሜን"
    };

    const englishMonths = {
        "01": "Jan",
        "02": "Feb",
        "03": "Mar",
        "04": "Apr",
        "05": "May",
        "06": "Jun",
        "07": "Jul",
        "08": "Aug",
        "09": "Sep",
        "10": "Oct",
        "11": "Nov",
        "12": "Dec"
    };

    // find google form by id
    const form = FormApp.openById("FORMID");

    // take the latest form submission from all of the form submissions 
    const latestFormResponses = form.getResponses()[form.getResponses().length - 1].getItemResponses();

    const reformatDate = (newDate, index) => {

        // create array separating the month(splitDate[1]) day(splitDate[2]) and year(splitDate[0])
        const splitDate = newDate.split("-");

        // index 6 and 8 are the ethiopian dates on the form
        if (index === 6 || index === 8) {

            // check if date given is between sep 1 to sep 5, and if it is, return the month as the 13th month
            if (splitDate[1] === "01" && (Number(splitDate[2]) >= 1 && Number(splitDate[2]) <= 5)) {
                return `${ethiopianMonths["13"]} ${splitDate[2]}/${splitDate[0]}`;
            }; 

            // return formatted date with ethiopian month
            return `${ethiopianMonths[splitDate[1]]} ${splitDate[2]}/${splitDate[0]}`;

        } else if (index === 5 || index == 7) {

            // return formatted date with english month
            return `${englishMonths[splitDate[1]]} ${splitDate[2]}/${splitDate[0]}`;

        };
    };

    // iterate through responses and add to the responses array
    for (let i = 0; i < latestFormResponses.length; i++) {

        // all the dates are from index 5 to 8 
        if (i >= 5 && i <= 8) {
            responses.push(reformatDate(latestFormResponses[i].getResponse(), i));
        } else {
            responses.push(latestFormResponses[i].getResponse());
        };
    };

    // get "empty shell" google doc template by id
    const template = DriveApp.getFileById("DOCID");

    // get folder for where the final product will be stored
    const finishedCertificateFolder = DriveApp.getFolderById("FOLDERID");

    // create a new file of the empty shell google doc inside of the folder
    const copy = template.makeCopy(`${responses[0]} ${responses[1]}'s Baptism Certificate`, finishedCertificateFolder);

    // open the new file
    const newDoc = DocumentApp.openById(copy.getId());

    // create access to actual text in the new file
    const docBody = newDoc.getBody();

    // start replacing the placeholder texts (they have {{ }} around them) with the values from the form (the numbers are the index corresponding with the order of the form's questions)
    docBody.replaceText("{{Name}}", `${responses[0]} ${responses[1]}`);
    docBody.replaceText("{{Amharic Name}}", `${responses[2]}`);
    docBody.replaceText("{{Father`s Name}}", `${responses[3]}`);
    docBody.replaceText("{{Amharic Father`s Name}}", `${responses[4]}`);
    docBody.replaceText("{{Date of Birth}}", `${responses[5]}`);
    docBody.replaceText("{{Amharic Date of Birth}}", `${responses[6]}`);
    docBody.replaceText("{{Date of Baptism}}", `${responses[7]}`);
    docBody.replaceText("{{Amharic Date of Baptism}}", `${responses[8]}`);
    docBody.replaceText("{{Godfather`s or mother`s name}}", `${responses[9]}`);
    docBody.replaceText("{{Amharic Godfather`s or mother`s name}}", `${responses[10]}`);
    docBody.replaceText("{{Baptismal Name}}", `${responses[11]}`);
    docBody.replaceText("{{Amharic Baptismal Name}}", `${responses[12]}`);
    docBody.replaceText("{{Mother`s Name}}", `${responses[13]}`);
    docBody.replaceText("{{Amharic Mother`s Name}}", `${responses[14]}`);
    docBody.replaceText("{{Place of Birth}}", `${responses[15]}`);
    docBody.replaceText("{{Amharic Place of Birth}}", `${responses[16]}`);

    newDoc.saveAndClose();

}
