/// <reference path="~/Scripts/jquery-1.4.1.js" />

$(setupPopup);

function setupPopup() {
	window.popupPlaceholder = $('<div id="popup" />').prependTo('body').hide();
	window.popupBackgroundPlaceholder = $('<div id="popupBackground" />').prependTo('body').hide();

	window.popupBackgroundPlaceholder.click(resetBackground);
}

function dimBackground() {
	popupBackgroundPlaceholder.css({ "opacity": "0.75" }).fadeIn("fast");
}

function resetBackground() {
	popupPlaceholder.fadeOut("fast");
	popupBackgroundPlaceholder.fadeOut("fast");
}

function showPopup() {
	centerPopup();
	popupPlaceholder.fadeIn('slow');
	if (jQuery.validator != undefined && jQuery.validate != undefined) {
		$.validator.unobtrusive.parse('form');
	}
}

function centerPopup() {
	var windowWidth = document.documentElement.clientWidth;
	var windowHeight = document.documentElement.clientHeight;
	var popupHeight = $("#popup").height();
	var popupWidth = $("#popup").width();

	$("#popup").css({
		top: windowHeight / 2 - popupHeight / 2,
		left: windowWidth / 2 - popupWidth / 2
	});
}