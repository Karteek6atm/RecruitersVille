function addnewexperience() {
    var experiecnes = $('#divexperiences').find('.newexp').length;

    var div = '<div class="newexp">' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>Company <span class="mandatory">*</span></label>' +
                    '<input class="form-control" placeholder="" id="textcompanyname" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>Location <span class="mandatory">*</span></label>' +
                    '<input class="form-control" placeholder="" id="textlocation" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>Designation <span class="mandatory">*</span></label>' +
                    '<input class="form-control" placeholder="" id="textdesignation" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>From Date <span class="mandatory">*</span></label>' +
                    '<input class="form-control datepicker" placeholder="" id="textfromdate" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>To Date <span class="mandatory">*</span></label>' +
                    '<input class="form-control datepicker" placeholder="" id="texttodate" type="text" onblur="validatetextbox(this)" />' +
                 '</div>' +
               '</div>' +
               '<div class="col-md-4">' +
                '<div class="form-group">' +
                    '<label>' +
                      '<input name="remember" type="checkbox" id="checkcurrentcompany" value="Current Company">Current Company?' +
                    '</label>' +
                 '</div>' +
               '</div>' +
             '</div>';
                
    $('#divexperiences').append(div);
    $('.datepicker').datepicker();
}