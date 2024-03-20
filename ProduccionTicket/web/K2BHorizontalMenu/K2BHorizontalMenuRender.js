function K2BHorizontalMenu(jQuery)
{
	this._$ = jQuery;
	this.MenuItems;
	this.IncludeSearch;
	this.SelectedItem = '';
	var _menu = this;
	
	// Databinding for property MenuItems
	this.SetMenuItems = function(data)
	{
		if ((this.MenuItems === undefined )  || (JSON.stringify(this.MenuItems) !== JSON.stringify(data)))
		{	
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
	
	// Databinding for property SelectedItem
	this.SetSelectedItem = function(data)
	{
		// Ignore value
	}

	// Databinding for property SelectedItem
	this.GetSelectedItem = function()
	{
		///UserCodeRegionStart:[GetMenuItems] (do not remove this comment.)
	    return this.SelectedItem;
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	
	this.show = function () {
	    ///UserCodeRegionStart:[show] (do not remove this comment.)
		
		if (!this.IsPostBack) {
			this.createMenuContainerStructure();
	    }
		

	    ///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)

	this.updateMenuContents = function(){
		var ulNode = this._$("#"+this.ContainerName+" ul.navbar-nav.K2BToolsHorizontalMenu");
		$(ulNode).empty();
		
		this.loadMenuData(this.MenuItems, 0, ulNode);
		
		var urlComps = window.location.pathname.split("/");
		var scriptName = urlComps[urlComps.length-1];
		var currentWPinMenu = false;
		_menu._$("UL.K2BHorizontalMenu a").each(function(i, item){
			if(_menu._$(item).attr("href") == scriptName){
				currentWPinMenu = true;
			}
		});
		
		if(currentWPinMenu){
			_menu._$("UL.K2BHorizontalMenu li").removeClass("active");
			_menu._$("UL.K2BHorizontalMenu a").each(function(i, item){
				if(_menu._$(item).attr("href") == scriptName){
					_menu._$(item).closest("li").addClass("active");
				}
			});
		}
	
		_menu._$.each(_menu._$("UL.K2BMetisMenu a"), function(i, element){
			if ((_menu._$(element).attr("href")!="") && (_menu._$(element).attr("href")!=undefined))
			_menu._$(element).on("click", _menu.onMenuClick);
		});
		
		if(this.IncludeSearch)
		{
			var inputLi = this._$('<li>');
			inputLi.addClass("searchItem");
			ulNode.append(inputLi);
			
			var searchField = this._$('<input>').addClass("searchField");
			searchField.attr("title", this.SearchInviteMessage);
			inputLi.append(searchField);
			
			var timer;
			this._$(searchField).bind('input',function(){
				window.clearTimeout(timer);
				timer = window.setTimeout(function(){
					_menu.updateSearchResults($(searchField).val())
				}, 600);
			});
			
			var searchResults = this._$('<div>').addClass("searchResults").hide();
			inputLi.append(searchResults);
		}
	}
	
	this.createMenuContainerStructure = function(){
		var container = this._$("#"+this.ContainerName);
		var navBarNode = this._$('<div>');
		navBarNode.attr("role", 'navigation');
		container.append(navBarNode);
	
		var mainNavigationBar = this._$('<div>').addClass('collapse navbar-collapse');
		navBarNode.append(mainNavigationBar);

		var mainUL = this._$('<ul>').addClass('nav navbar-nav K2BToolsHorizontalMenu');
		mainNavigationBar.append(mainUL);
		
		this.updateMenuContents();
	}
	
	this.onMenuClick = function(){ 
		_menu._$("UL.K2BToolsHorizontalMenu li").removeClass("active");
		_menu._$(this).closest("li").addClass("active");
	}
	
	this.loadMenuData = function (MenuData, step, currentNode) {
	 
	    var i = 0;
	    for (i = 0; MenuData[i] != undefined; i++) {
		
			hasFontAwesome = MenuData[i].ImageClass!=undefined && MenuData[i].ImageClass != null && MenuData[i].ImageClass.trim() != "";
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
				if(!_menu._$(currentNode).hasClass("navbar-nav"))
					liElement.addClass("dropdown-submenu");
				
				var linkElement = _menu._$('<a></a>')
				//href="#" class="dropdown-toggle" data-toggle="dropdown"
				linkElement.attr("href", "#");
				linkElement.addClass("dropdown-toggle");
				linkElement.attr("data-toggle", "dropdown");
				liElement.append(linkElement);
				
				if (hasFontAwesome){
					var spanElement = _menu._$('<span>').addClass('sidebar-nav-item-icon').addClass(MenuData[i].ImageClass);
					linkElement.append(spanElement);
				}
				
	    		if (hasImage){
					var image = _menu._$('<img>').attr('src', MenuData[i].ImageUrl).addClass('sidebar-nav-item-icon').addClass('K2BMenuItemImage').addClass(MenuData[i].ImageClass);
					linkElement.append(image);
				}
				
				if (hasImage || hasFontAwesome){
					linkElement.append(_menu._$("<span>").addClass("sidebar-nav-item").text(MenuData[i].Title));
				}else{
					linkElement.text(MenuData[i].Title);
				}
				
				var newUl = _menu._$('<ul>').addClass('dropdown-menu multi-level');
				liElement.append(newUl);
	            this.loadMenuData(MenuData[i].Items, step +1, newUl);
	        } else {
	            linkObject = _menu._$('<a>')
				if(MenuData[i].Link != "" && MenuData[i].Link != null){
					linkObject.attr('href', MenuData[i].Link);
				}else{
					var uc = this;
					linkObject.on('click', {code: MenuData[i].Code}, function(e){
						uc.SelectedItem = e.data.code;
						if(uc.OptionClicked != null && typeof(uc.OptionClicked == 'function'))
							uc.OptionClicked();
					});;
				}
				liElement.append(linkObject);
				
				if (hasFontAwesome){
					var spamFontAwesome = _menu._$('<span>').addClass('sidebar-nav-item-icon').addClass(MenuData[i].ImageClass);
					linkObject.append(spamFontAwesome);
				}
				
				if (hasImage){
					imageObject = $('<img>').attr('src', MenuData[i].ImageUrl).addClass('sidebar-nav-item-icon').addClass('K2BMenuItemImage').addClass(MenuData[i].ImageClass);
					linkObject.append(imageObject);
				}
				linkObject.append(document.createTextNode(MenuData[i].Title));
	        }
	    }
		return;
	}
	
	this.updateSearchResults = function(criteria){
		//Initialize 
		var searchResults = $(".K2BToolsHorizontalMenu div.searchResults");
		searchResults.empty();
		if(criteria == undefined || criteria == ""){
			searchResults.hide();
		}else{
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
	///UserCodeRegionEnd: (do not remove this comment.):
}
