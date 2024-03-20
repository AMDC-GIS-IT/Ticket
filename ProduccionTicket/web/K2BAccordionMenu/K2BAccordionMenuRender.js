function K2BAccordionMenu(jQuery)
{
	this._$ = jQuery;
	this.MenuItems;
	this.Toggle;
	this.DoubleTapGo;
	this.IncludeSearch;
	var _menu = this;
	
	// Databinding for property MenuItems
	this.SetMenuItems = function(data)
	{
		if ((this.MenuItems === undefined )  || (JSON.stringify(this.MenuItems) !== JSON.stringify(data)))
		{	
			_menu._$("#" + _menu.ControlName).metisMenu('dispose');
			this.MenuItems = data;
		///UserCodeRegionEnd: (do not remove this comment.)
			this.updateMenuContents();
		}
	}

	// Databinding for property MenuItems
	this.GetMenuItems = function()
	{
		///UserCodeRegionStart:[GetMenuItems] (do not remove this comment.)
	    return this.MenuItems;
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	
	this.show = function () {
	    ///UserCodeRegionStart:[show] (do not remove this comment.)
		
		if (!this.IsPostBack) {
			this.createMenuContainerStructure();
	    }
		_menu._$(document).ready(this.htmlClickCallback);
		
		_menu._$(document).on('click', function(e){
			if(!_menu._$(e.target).hasClass("K2BToolsButton_BtnToggle") && _menu._$(e.target).closest(".Calendar").length==0){
				_menu._$(".K2BToolsMenuContainerVisibleCompact").each(function(index, element){
					
					if (_menu._$(e.target).closest(element).length < 1) {
						_menu._$(element).removeClass("K2BToolsMenuContainerVisibleCompact");
						_menu._$(element).addClass("K2BToolsMenuContainerInvisibleCompact");
					}
				});
			}
		});

	    ///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)

	this.updateMenuContents = function(){
		var ulNode = this._$("#"+this.ContainerName+" ul.K2BMetisMenu");
		$(ulNode).empty();
		this.loadMenuData(this.MenuItems, 0, ulNode);
		
		var urlComps = window.location.pathname.split("/");
		var scriptName = urlComps[urlComps.length-1];
		var currentWPinMenu = false;
		_menu._$("UL.K2BMetisMenu a").each(function(i, item){
			if(_menu._$(item).attr("href") == scriptName){
				currentWPinMenu = true;
			}
		});
		
		if(currentWPinMenu){
			_menu._$("UL.K2BMetisMenu li").removeClass("activeelement");
			_menu._$("UL.K2BMetisMenu a").each(function(i, item){
				if(_menu._$(item).attr("href") == scriptName){
					_menu._$(item).closest("li").addClass("activeelement");
				}
			});
		}
	
		_menu._$.each(_menu._$("UL.K2BMetisMenu a"), function(i, element){
			if ((_menu._$(element).attr("href")!="") && (_menu._$(element).attr("href")!=undefined))
			_menu._$(element).on("click", _menu.onMenuClick);
		});
	}
	
	this.updateSearchResults = function(criteria){
		//Initialize 
		var menu = $("#"+this.ContainerName+" aside.sidebar > nav.sidebar-nav > ul.K2BMetisMenu");
		var searchResults = $("#"+this.ContainerName+" aside.sidebar > nav.sidebar-nav > div.searchResults");
		searchResults.empty();
		if(criteria == undefined || criteria == ""){
			menu.show();
			searchResults.hide();
		}else{
			menu.hide();
			searchResults.show();
		}
			
		this.getSearchResults_Recursive(this.MenuItems, criteria,[], searchResults);
	}
	
	this.getSearchResults_Recursive = function(menuLevel, criteria, path, searchResults){
		for(var i =0;i<menuLevel.length;i++){
			var item = menuLevel[i];
			if(item.Items == undefined || item.Items.length == 0){
				if(item.Title.toLowerCase().includes(criteria.toLowerCase())){
					var link = this._$('<a>').attr('href', item.Link);
					
					var searchResult = this._$('<div>').addClass('searchResult');
					
					var index = item.Title.toLowerCase().indexOf(criteria.toLowerCase());
					var title = this._$('<span>').addClass('searchResultTitle');
					title.append(document.createTextNode(item.Title.substring(0,index)));
					var highlight = this._$("<span>").addClass('searchResultHighlight').text(item.Title.substring(index,index+criteria.length));
					title.append(highlight);
					title.append(document.createTextNode(item.Title.substring(index + criteria.length)));
					
					searchResult.append(title);
					var pathStr = Array.prototype.join.call(path, ' » ');
					var pathSpan = this._$('<span>').addClass('searchResultPath').text(pathStr);
					pathSpan.attr("title", pathStr);
					searchResult.append(pathSpan);
					
					link.append(searchResult);
					searchResults.append(link);
				}
			}else{
				var newpath = path.slice();
				Array.prototype.push.call(newpath,item.Title);
				this.getSearchResults_Recursive(item.Items, criteria, newpath, searchResults);
			}
		}
	}
	
	this.createMenuContainerStructure = function(){
		var container = this._$("#"+this.ContainerName);
		var rootNode = this._$('<aside>').addClass('sidebar');
		container.append(rootNode);
		
		var navNode = this._$('<nav>').addClass('sidebar-nav');
		rootNode.append(navNode);
		
		if(this.IncludeSearch){
			var searchField = this._$('<input>').addClass('searchField');
			searchField.attr("title", this.SearchInviteMessage);
			searchField.attr("placeholder", this.SearchInviteMessage);
			navNode.append(searchField);
			
			var timer;
			$(searchField).bind('input',function(){
				window.clearTimeout(timer);
				timer = window.setTimeout(function(){
					_menu.updateSearchResults($(searchField).val())
				}, 600);
				
			});
			
			$("nav.sidebar-nav").keydown(function(event) {
				var currentFocus = _menu._$(document.activeElement);
				if(event.which == 40){				
					if(currentFocus[0].nodeName.toLowerCase() == "a"){
						if(currentFocus.next().length > 0)
							currentFocus.next().focus();
						else
							_menu._$(".searchField").focus();
					}else if (currentFocus.hasClass("searchField")){
						_menu._$(".searchResults a:first-child").focus();
					}
					
					event.preventDefault();
				}else if(event.which == 38){
					if(currentFocus[0].nodeName.toLowerCase() == "a"){
						if(currentFocus.prev().length > 0)
							currentFocus.prev().focus();
						else
							_menu._$(".searchField").focus();
					}else if (currentFocus.hasClass("searchField")){
						_menu._$(".searchResults a:last-child").focus();
					}
					
					event.preventDefault();
				}else if (event.which == 13) {
					if(currentFocus[0].nodeName.toLowerCase() == "a"){
						$(currentFocus[0]).trigger('click');
					}
				}
			});
			
			_menu._$("nav.sidebar-nav").on('click', '.searchResults > a', function(){
				var parent = _menu._$(this).closest(".K2BToolsMenuContainerVisibleCompact");
				parent.removeClass("K2BToolsMenuContainerVisibleCompact");
				parent.addClass("K2BToolsMenuContainerInvisibleCompact");

				var link = _menu._$(this).attr("href");

				$(".searchField").val("");
				_menu.updateSearchResults("");
				window.location.href = link;
			});
		}
		
		var ulNode = this._$('<ul>').attr('id', this.ControlName).addClass('K2BMetisMenu');
		navNode.append(ulNode);
		
		var searchResults = this._$('<div>').addClass("searchResults").hide();
		navNode.append(searchResults);
		
		//this.setHtml(rootNode[0].outerHTML);
				
		this.updateMenuContents();
	}
	
	this.onMenuClick = function(){ 
		_menu._$("UL.K2BMetisMenu li").removeClass("activeelement");
		_menu._$(this).closest("li").addClass("activeelement");
		
		var parent = _menu._$(this).closest(".K2BToolsMenuContainerVisibleCompact");
		parent.removeClass("K2BToolsMenuContainerVisibleCompact");
		parent.addClass("K2BToolsMenuContainerInvisibleCompact");
	}
	
	this.loadMenuData = function (MenuData, step, currentNode) {
	 
	    var i = 0;
	    for (i = 0; MenuData[i] != undefined; i++) {
		
			hasFontAwesome =MenuData[i].ImageClass!=undefined && MenuData[i].ImageClass != null && MenuData[i].ImageClass.trim() != "";
			hasImage = MenuData[i].ImageUrl!=undefined && MenuData[i].ImageUrl != null && MenuData[i].ImageUrl.trim() != "";
			var liElement = _menu._$('<li>')
			if (!MenuData[i].ShowInExtraSmall)
			{
				liElement.addClass("InvisibleInExtraSmallMenu");
			}
			
			if (!MenuData[i].ShowInSmall){
				liElement.addClass("InvisibleInSmallMenu");
			}
			
			if (!MenuData[i].ShowInMedium){
				liElement.addClass("InvisibleInMediumMenu");
			}
			
			if (!MenuData[i].ShowInLarge){
				liElement.addClass("InvisibleInLargeMenu");
			}
			
			currentNode.append(liElement);
			
	        if (MenuData[i].Items != undefined && MenuData[i].Items.toString() != ""){
				var linkElement = _menu._$('<a></a>')
				liElement.append(linkElement);
	    		if (hasFontAwesome){
					var spanElement = _menu._$('<span>').addClass('sidebar-nav-item-icon').addClass(MenuData[i].ImageClass);
					linkElement.append(spanElement);
				}
				
				if (hasImage){
					var image = _menu._$('<img>').attr('src', MenuData[i].ImageUrl).addClass('sidebar-nav-item-icon').addClass('K2BMenuItemImage').addClass(MenuData[i].ImageClass);
					linkElement.append(image);
				}
				
				linkElement.append(_menu._$("<span>").addClass("sidebar-nav-item").text(MenuData[i].Title));
				
				linkElement.append(_menu._$('<span>').addClass('fa').addClass('arrow'));
				
				var newUl = _menu._$('<ul>');
				liElement.append(newUl);
	            this.loadMenuData(MenuData[i].Items, step +1, newUl);
	        } else {
	            linkObject = _menu._$('<a>').attr('href', MenuData[i].Link);
				liElement.append(linkObject);
				
				if (hasFontAwesome){
					var spamFontAwesome = _menu._$('<span>').addClass('sidebar-nav-item-icon').addClass(MenuData[i].ImageClass);
					linkObject.append(spamFontAwesome);
				}
				
				if (hasImage){
					imageObject = $('<img>').attr('src', MenuData[i].ImageUrl).addClass('sidebar-nav-item-icon').addClass('K2BMenuItemImage').addClass(MenuData[i].ImageClass);
					linkObject.append(imageObject);
				}
				linkObject.append(_menu._$("<span>").addClass("sidebar-nav-item").text(MenuData[i].Title));
	        }
	    }
		return;
	}
	
	this.htmlClickCallback = function(e)
	{
		_menu._$("#" + _menu.ControlName).metisMenu({toggle: _menu.Toggle, doubleTapGo: _menu.DoubleTapGo});
	}
	///UserCodeRegionEnd: (do not remove this comment.):
}
