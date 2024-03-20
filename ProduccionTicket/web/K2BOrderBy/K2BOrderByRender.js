function K2BOrderBy(JQuery) {
	this.GridOrders;
	this.GridControlName;
	this.SelectedGridOrder;
	this._JQuery = JQuery;

	// Databinding for property GridOrders
	this.SetGridOrders = function (data) {
		///UserCodeRegionStart:[SetGridOrders] (do not remove this comment.)
		this.GridOrders = data;
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property GridOrders
	this.GetGridOrders = function () {
		///UserCodeRegionStart:[GetGridOrders] (do not remove this comment.)
		return this.GridOrders;
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.SetSelectedGridOrder = function (data) {
		///UserCodeRegionStart:[SetGridOrders] (do not remove this comment.)
		this.SelectedGridOrder = data;
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property GridOrders
	this.GetSelectedGridOrder = function () {
		///UserCodeRegionStart:[GetGridOrders] (do not remove this comment.)
		return this.SelectedGridOrder;
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.show = function () {
		var that = this;
		var gridTable = this._JQuery("th.K2BToolsSortableColumn")
			.closest("table")
			.filter(function (index) {
				return that._JQuery(this).attr("id").toLowerCase() == that.GetGridTableName(that.GridControlName).toLowerCase()
			});

		for (i = 0; this.GridOrders[i] != undefined; i++) {
			var zeroBasedIndex = this.GridOrders[i].GridColumnIndex - 1;
			var column = gridTable.find('th.K2BToolsSortableColumn:eq(' + zeroBasedIndex + ')');
			column.click({
				ascOrder : this.GridOrders[i].AscendingOrder,
				descOrder : this.GridOrders[i].DescendingOrder
			}, function (e) {

				var clickElement = that._JQuery(this);
				var gridId = clickElement.closest("table").attr("id").toLowerCase();

				if (e.data.ascOrder == -1) {
					clickElement.addClass("GridColumnDescending");
					that.SelectedGridOrder = e.data.descOrder;
				} else if (e.data.descOrder == -1) {
					clickElement.addClass("GridColumnAscending");
					that.SelectedGridOrder = e.data.ascOrder;
				} else if (clickElement.hasClass("GridColumnDescending")) {
					clickElement.addClass("GridColumnAscending");
					that.SelectedGridOrder = e.data.ascOrder;
				} else if (clickElement.hasClass("GridColumnAscending")) {
					clickElement.addClass("GridColumnDescending");
					that.SelectedGridOrder = e.data.descOrder;
				} else {
					if(e.data.ascOrder < e.data.descOrder){
						clickElement.addClass("GridColumnAscending");
						that.SelectedGridOrder = e.data.ascOrder;
					}else{
						clickElement.addClass("GridColumnDescending");
						that.SelectedGridOrder = e.data.descOrder;
					}
				}

				if (typeof(that.OrderByChanged) == 'function')
					that.OrderByChanged();
			});
			if (this.GridOrders[i].AscendingOrder == this.SelectedGridOrder) {
				column.addClass("GridColumnAscending");
			} else {
				column.removeClass("GridColumnAscending");
			}

			if (this.GridOrders[i].DescendingOrder == this.SelectedGridOrder) {
				column.addClass("GridColumnDescending");
			} else {
				column.removeClass("GridColumnDescending");
			}

		}
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)

	this.GetGridTableName = function (controlName) {
		return controlName + 'ContainerTbl';
	}

	///UserCodeRegionEnd: (do not remove this comment.):
}
