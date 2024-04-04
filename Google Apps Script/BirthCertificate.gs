function BaptismCertificate() {

    const responses = [];

    const form = FormApp.openById("FORMSID");
    const latestFormResponses = form.getResponses()[form.getResponses().length - 1].getItemResponses();

    for (let i = 0; i < latestFormResponses.length; i++) {
        responses.push(latestFormResponses[i].getResponse());
    };

    const template = DriveApp.getFileById("DOCID");
    const renderedFolder = DriveApp.getFolderById("FOLDERID");

    const copy = template.makeCopy(`${responses[0]} ${responses[1]}'s Baptism Certificate`, renderedFolder);
    const newDoc = DocumentApp.openById(copy.getId());

    const docBody = newDoc.getBody();

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
