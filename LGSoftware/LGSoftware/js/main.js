function LoadPagina(){  
    $('#Menu').text = "teste";
    //var posicaoInicial = $('#Menu').position().top;
    //    var posicaoScroll = $(document).scrollTop(); // obtem a quantidade de scroll no momento
    //if (posicaoInicial < posicaoScroll)  $('#Menu').removeClass; $('#Menu').addClass("header-section menu_fixed animated fadeInDown");
    }

'use strict';


$(window).on('load', function() {
	/*------------------
		Preloder
	--------------------*/
	$(".loader").fadeOut();
	$("#preloder").delay(400).fadeOut("slow");

});

(function($) {
	/*------------------
		Navigation
	--------------------*/
	$('.primary-menu').slicknav({
		appendTo:'.header-warp',
		closedSymbol: '<i class="fa fa-angle-down"></i>',
		openedSymbol: '<i class="fa fa-angle-up"></i>'
	});


	/*------------------
		Background Set
	--------------------*/
	$('.set-bg').each(function() {
		var bg = $(this).data('setbg');
		$(this).css('background-image', 'url(' + bg + ')');
	});



	/*------------------
		Hero Slider
	--------------------*/
	$('.hero-slider').owlCarousel({
		loop: true,
		nav: true,
		dots: true,
		navText: ['', '<img src="img/icons/solid-right-arrow.png">'],
		mouseDrag: false,
		animateOut: 'fadeOut',
		animateIn: 'fadeIn',
		items: 1,
		//autoplay: true,
		autoplayTimeout: 10000,
	});

	var dot = $('.hero-slider .owl-dot');
	dot.each(function() {
		var index = $(this).index() + 1;
		if(index < 10){
			$(this).html('0').append(index + '.');
		}else{
			$(this).html(index + '.');
		}
	});



	/*------------------
		Video Popup
	--------------------*/
	$('.video-popup').magnificPopup({
  		type: 'iframe'
	});

	$('#stickySidebar').stickySidebar({
	    topSpacing: 60,
	    bottomSpacing: 60
	});


})(jQuery);
