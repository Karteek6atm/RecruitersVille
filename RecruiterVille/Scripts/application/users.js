function getuserslist() {
    hideallalerts();
    showloading();
    $('#tbodyusers tr').remove();

    $.ajax({
        type: "GET",
        url: "/recruiter/getuserslist",
        dataType: "json",
        success: function (data) {
            var ishavingusers = true;

            if (data != null) {
                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var tr = $('<tr />');
                        var address = (data[i].Street == "") ? "" : data[i].Street;
                        address = (address == "") ? data[i].City : address + ((data[i].City == "") ? "" : ", " + data[i].City);
                        address = (address == "") ? data[i].State : address + ((data[i].State == "") ? "" : ", " + data[i].State);
                        address = (address == "") ? data[i].State : address + ((data[i].State == "") ? "" : ", " + data[i].State);
                        address = (address == "") ? data[i].Country : address + ((data[i].Country == "") ? "" : ", " + data[i].Country);
                        address = (address == "") ? data[i].Zipcode : address + ((data[i].Zipcode == "") ? "" : " - " + data[i].Zipcode);

                        $(tr).append('<td>' + (i + 1) + '<input type="hidden" id="hiddenuserid" value="' + data[i].UserId + '" /></td>' +
                                    '<td>' + data[i].FullName + '</td>' +
                                    '<td>' + data[i].EmailId + '</td>' +
                                    '<td>' + data[i].ContactNumber + '</td>' +
                                    '<td>' + data[i].RoleName + '</td>' +
                                    '<td>' + data[i].Designation + '</td>' +
                                    '<td>' + address + '</td>' +
                                    '<td>&nbsp;</td>');

                        $('#tbodyusers').append(tr);
                    }
                }
                else {
                    ishavingusers = false;
                }
            }
            else {
                ishavingusers = false;
            }

            if (!ishavingusers) {
                var tr = '<tr />';
                $(tr).append('<td colspan="8">No users found in your company.</td>');
                $('#tbodyusers').append(tr);
            }

            hideloading();
        },
        error: function (xhr) {
            hideloading();
            showerroralert(xhr.responseText);
        }
    });
}