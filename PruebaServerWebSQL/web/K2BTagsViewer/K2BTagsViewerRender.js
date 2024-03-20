function K2BTagsViewer(JQuery) {
	this.TagValues;
	this.DeletedTag;
	this.EmptyStateMessage;
	this.$ = JQuery;
	var uc = this;

	// Databinding for property TagValues
	this.SetTagValues = function (data) {
		this.TagValues = data;
	}

	// Databinding for property TagValues
	this.GetTagValues = function () {
		return this.TagValues;
	}
	
	// Databinding for property DeletedTag
	this.SetDeletedTag = function (data) {
		this.DeletedTag = data;
	}

	// Databinding for property DeletedTag
	this.GetDeletedTag = function () {
		return this.DeletedTag;
	}

	this.show = function () {	
		var container = this.$("#"+this.ContainerName);
		container.empty();
		
		container.addClass("K2BT_TagsCollectionContainer");
		for (i = 0; this.TagValues[i] != undefined; i++) {
			div = this.$("<div class='K2BT_TagsCollectionItem' />");
			title = this.$("<span class='K2BT_TagsCollectionItemTitle' />");
			closebutton = this.$("<span class='K2BT_TagsCollectionItemClose' />");
			
			div.attr("data-k2btools-itemid", this.TagValues[i].Value);
			title.text(this.TagValues[i].Description);
			
			div.append(title);
			div.append(closebutton);
			container.append(div);
			
			this.$(closebutton).on("click", function(e){
				uc.DeletedTag = uc.$(e.target).closest(".K2BT_TagsCollectionItem").attr("data-k2btools-itemid");
				if (typeof(uc.TagDeleted) == 'function')
					uc.TagDeleted();
			});
		}
		
		if(this.TagValues == null || this.TagValues == undefined || this.TagValues.length == 0){
			var emptyStateMessage = this.$("<span class='K2BT_TagsCollectionEmptyMessage' />");
			emptyStateMessage.text(this.EmptyStateMessage);
			
			container.append(emptyStateMessage);
		}
	}
}
