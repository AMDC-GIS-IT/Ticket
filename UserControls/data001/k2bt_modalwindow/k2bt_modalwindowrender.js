function K2BT_ModalWindow($) {
	  

	var template = '<div class=\"Table_ConditionalConfirm\">	<div class=\"K2BT_ModalWindow\">		<div class=\"K2BT_ModalWindowHeader\">			<div class=\"K2BT_ModalWindowTitle\">{{ModalTitle}}</div>			<div class=\"K2BT_ModalWindowClose\"  data-event=\"OnClose\" >×</div>		</div>		<div class=\"K2BT_ModalWindowContent\">			<div data-slot=\"ModalContent\" data-parent=\"{{ContainerName}}\"></div>		</div>	</div></div>';
	Mustache.parse(template);
	var _iOnOnClose = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnOnClose = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='OnClose']")
				.on('click', this.onOnCloseHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts

	}

	this.Scripts = [];



		this.onOnCloseHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
			}

			if (this.OnClose) {
				this.OnClose();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}