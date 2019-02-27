           
            
        //slick slider (partners section)
        if ($('.sponsor-slider').length) {
            $('.sponsor-slider').slick({
                centerMode: true,
                centerPadding: '30px',
                slidesToShow: 4,
                autoplay: true,
                arrows: false,
                responsive: [{
                    breakpoint: 768,
                    settings: {
                        arrows: false,
                        centerMode: true,
                        centerPadding: '40px',
                        slidesToShow: 3
                    }
            }, {
                    breakpoint: 480,
                    settings: {
                        arrows: false,
                        centerMode: true,
                        centerPadding: '40px',
                        slidesToShow: 1
                    }
            }]
            });
            
        }
        
       













            
             // validate form on keyup and submit
		$(".contact-form").validate({
			rules: {
				
				lastname: "required",
				first_name: {
					required: true,
					minlength: 5
				},
				password: {
					required: true,
					minlength: 5
				},
				confirm_password: {
					required: true,
					minlength: 5,
					equalTo: "#password"
				},
				email: {
                   
					required: true,
					
				},
				number: {
					required: true,
					minlength: 10,
                    maxlength:10,
                   
				},
                opt1:{
                    required: true,
                },
                quantity2:{
                    required: true,
                },
                
				agree: "required"
			},
			messages: {
				first_name: "Please enter your Full Name",
				lastname: "Please enter your lastname",
				username: {
					required: "Please enter a username",
					minlength: "Your username must consist of at least 2 characters"
				},
				password: {
					required: "Please provide a password",
					minlength: "Your password must be at least 5 characters long"
				},
                number: {
					required: "Please provide valid number",
					minlength: "mobile number must be 10 digists"
				},
                opt1:{
                    required: "Please select an option",
                }, 
                quantity2:{
                    required: "Please select an option",
                },
				confirm_password: {
					required: "Please provide a password",
					minlength: "Your password must be at least 5 characters long",
					equalTo: "Please enter the same password as above"
				},
				email: "Please enter a valid email address",
				agree: "Please accept our policy"
			}
		});
       