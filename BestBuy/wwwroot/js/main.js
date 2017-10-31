$(document).ready(function() {
	$(".selectize").each(function () {
		$(this).selectize();
	});

	$(".selectize-tags").each(function () {
		$(this).selectize({
			plugins: ["remove_button", "drag_drop"],
			delimiter: ",",
			persist: false,
			create: function (input) {
				return {
					value: input,
					text: input
				}
			}
		});
	});

	var sideMenuToggle = $(".sideMenuToggle");

	sideMenuToggle.click(function (e) {
		e.preventDefault();
		var body = $("body");
		if (body.hasClass("mtSidebarOpen")) {
			var sidebarCollapsedLink = $(".mtSidebar a[data-toggle='collapse']:not(.collapsed)");
			sidebarCollapsedLink.addClass("collapsed");
			var sidebarCollapsedPanel = $(".mtSidebar .panel-collapse.in");
			sidebarCollapsedPanel.removeClass("in");
		}
		body.toggleClass("mtSidebarOpen");
	});

	var sidebarHeadingCollapseLink = $(".mtSidebar .panel-heading a[data-toggle='collapse']");

	sidebarHeadingCollapseLink.click(function () {
		if (!$("body").hasClass("mtSidebarOpen")) {
			return false;
		}
	});

	var contentWrapper = ".contentWrapper";
	var headerHeight = $("header").height();
	var footerHeight = $("footer").height();

	function contentWrapperHeight() {
		var calcHeight = $(window).height() - headerHeight - footerHeight;
		var sidebarHeight = $(".mtSidebar > .sidebar-menu").height() - footerHeight;
		if (calcHeight <= sidebarHeight) {
			$(contentWrapper).css("min-height", sidebarHeight);
		}
		else {
			$(contentWrapper).css("min-height", calcHeight);
		}
	}

	contentWrapperHeight();
	$("footer").removeClass("invisibile");

	$(window).resize(function() {
		contentWrapperHeight();
	});
});