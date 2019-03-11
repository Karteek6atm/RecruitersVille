function SendContactMessage() {
    hideallalerts();
    var textname = $("#textname");
    var textemailid = $("#textemailid");
    var textsubject = $("#textsubject");
    var textmessage = $("#textmessage");

    var isvalid = true;
       
     if (validatetextbox(textname) == false) {
        isvalid = false;
    }
    if (validateemailid(textemailid) == false) {
        isvalid = false;
    }
    if (validatetextbox(textsubject) == false) {
        isvalid = false;
    }
    if (validatetextbox(textmessage) == false) {
        isvalid = false;
    }

    if (isvalid) {
        showloading();

        var input = [];
        input = {
            Name: textname.val().trim(),
            EmailId: textemailid.val().trim(),
            Subject: textsubject.val().trim(),
            Message: textmessage.val().trim()
        };

        $.ajax({
            type: "POST",
            data: (input),
            url: "/account/sendcontactusrequest",
            dataType: "json",
            success: function (data) {
                if (data.StatusId == 1) {
                    showsuccessalert(data.StatusMessage);
                    textname.val('');
                    textemailid.val('');
                    textsubject.val('');
                    textmessage.val('');
                }
                else {
                    showwarningalert(data.StatusMessage);
                }
                hideloading();
            },
            error: function (xhr) {
                hideloading();
                showerroralert(xhr.responseText);
            }
        });
    }
    else {
        return false;
    }
}