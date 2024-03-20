// Fix to show image chooser in a non-modal window. SAC #42886
gx.html.multimediaUpload.isModal = false;

/* START - Global constants */

var k2btools = k2btools || {};

// Default value, if many instances are present then this properties will be set to false if any of the instances says so.
k2btools.updateCheckboxes = true;
k2btools.updateSelects = true;
k2btools.showMessagesAssociatedWithAttributes = true;

k2btools.checkboxSelector = 'input[type="checkbox"]:not(.bootstrap-switch *)';
k2btools.selectSelector = 'select.K2BToolsEnhancedCombo';

k2btools.createdSelects = k2btools.createdSelects || []; // Used to refresh already created selects
k2btools.messagesShown = k2btools.messagesShown || []; // Used to avoid duplicating messages

/* END - Global constants */

/* START - Mutation observers - Event Handling */
k2btools.checkboxRefresh =
  k2btools.checkboxRefresh ||
  function () {
    if (k2btools.updateCheckboxes) {
      k2btools.$(k2btools.checkboxSelector).each(function (i, el) {
        if (k2btools.$(el).next('label').length == 0) {
          label = k2btools.$("<label data-gx-sr-only='' />");
          label.attr('for', k2btools.$(el).attr('id'));
          k2btools.$(el).after(label);

          k2btools.$(el).parent('label').addClass('K2BT_CheckboxContainer');
        }
      });
    }
  };

k2btools.RefreshTooltips =
  k2btools.RefreshTooltips ||
  function () {
    k2btools.$(".tooltip[role='tooltip']").remove();
    k2btools.$('.Image_Action, .K2BImage_ContextHelp, .K2BContextHelp, .K2BT_EntityManagerSocialAction').each(function (i, element) {
      var $element = k2btools.$(element);
      $element.tooltip({ delay: { show: 500, hide: 500 }, container: $element.parent(), trigger: 'hover' });
    });

    k2btools.$('.Image_Action, .K2BImage_ContextHelp, .K2BContextHelp').on('click', function () {
      k2btools.$(this).tooltip('hide');
    });

    k2btools.$(".Image_Action[title!=''], .K2BImage_ContextHelp[title!=''], .K2BContextHelp[title!='']").each(function (i, element) {
      var $element = k2btools.$(element);
      $element.tooltip('hide').attr('data-original-title', $element.attr('title')).tooltip('fixTitle');
      $element.attr('title', '');
    });

    var element = k2btools.$(".K2BT_EntityManagerSocialAction[title!=''][title!=data-original-title]");
    k2btools.$(element).attr('data-original-title', element.attr('title')).tooltip('fixTitle').tooltip('show');
  };

k2btools.selectRefresh =
  k2btools.selectRefresh ||
  function () {
    if (k2btools.updateSelects) {
      k2btools.createdSelects = k2btools.$(k2btools.createdSelects).filter(function (index) {
        return k2btools.$.contains(document, this);
      });

      k2btools.$(k2btools.createdSelects).each(function (i, element) {
        k2btools.$(element).selectpicker('refresh');

        if (
          k2btools
            .$(element)
            .parents(
              '#K2BTABLEACTIONSLEFTCONTAINER, #K2BTABLEACTIONSRIGHTCONTAINER, #K2BTABLEGRIDACTIONSLEFTCONTAINER, #K2BTABLEGRIDACTIONSRIGHTCONTAINER, #K2BTABLEACTIONSTOPCONTAINER, #K2BTABLEACTIONSBOTTOMCONTAINER, .Table_ComboActionsContainer, .Table_ActionsContainer, .K2BToolsTableCell_ActionContainer',
            ).length > 0
        ) {
          if (k2btools.$(element).find('[value!=0]').length == 0 || k2btools.$(element).find("[value!='']").length == 0) {
            k2btools.$(element).selectpicker('hide');
          } else {
            k2btools.$(element).selectpicker('show');
          }
        }
      });
    }
  };

k2btools.ParentsCheck = function (element, hops) {
  i = 0;
  while (i < hops && element != document.documentElement && element.parentElement != null) {
    element = element.parentElement;
    i++;
  }
  return element.parentElement != null || element == document.documentElement;
};

k2btools.RefreshGridLastColumnTag = function () {
  k2btools.$('.gx-grid .Grid_WorkWith').each(function (i, grid) {
    k2btools.$(grid).find('th, td').removeClass('K2BToolsLastVisibleColumn');
    var lastColumnHeader = k2btools
      .$(grid)
      .find('tr th')
      .filter(function (index, el) {
        return k2btools.$(el).css('display') != 'none';
      })
      .last();
    lastColumnHeader.addClass('K2BToolsLastVisibleColumn');

    var colIndex = lastColumnHeader.attr('data-colindex');
    k2btools
      .$(grid)
      .find("td[data-colindex='" + colIndex + "']")
      .addClass('K2BToolsLastVisibleColumn');
  });
};

k2btools.afterEventObserver = function () {
  k2btools.checkboxRefresh();
  k2btools.selectRefresh();
  k2btools.RefreshTooltips();
  k2btools.RefreshGridLastColumnTag();
};

/* END - Mutation observers - Event Handling */

function K2BControlBeautify(jQuery) {
  k2btools.$ = jQuery;
  this.UpdateCheckboxes;
  this.UpdateSelects;

  this.show = function () {
    if (!this.UpdateSelects) k2btools.updateSelects = false;

    if (!this.UpdateCheckboxes) k2btools.updateCheckboxes = false;

    if (k2btools.updateCheckboxes) this.RefreshCheckboxes();

    if (k2btools.updateSelects) this.RefreshSelects();

    this.RefreshTooltips();
    this.RefreshMenu();
    this.RefreshMessageHandling();
    this.RefreshMenuHide();
    this.RefreshTagsCollectionFocus();

    var uc = this;
    setTimeout(function () {
      uc.RefreshGridSettingsPosition();
    }, 500);

    this.RefreshOnImagePrompt();
    k2btools.RefreshGridLastColumnTag();

    gx.fx.obs.addObserver('gx.onafterevent', k2btools, k2btools.afterEventObserver, { single: false, unique: true });
    gx.fx.obs.addObserver('grid.onafterrender', k2btools, k2btools.afterEventObserver, { single: false, unique: true });
  };

  this.RefreshGridSettingsPosition = function () {
    k2btools.$('.K2BToolsTable_GridSettings').each(function (i, item) {
      var itemWidth = k2btools.$(item).outerWidth();
      var parentWidth = k2btools.$(item).closest('.K2BToolsTable_GridSettingsContainer').outerWidth();

      var left = itemWidth - parentWidth;
      k2btools.$(item).css({ left: -left });
    });

    k2btools.$('.K2BToolsDownloadActionsTable').each(function (i, item) {
      var itemWidth = k2btools.$(item).outerWidth();
      var parentWidth = k2btools.$(item).closest('.K2BToolsTable_DownloadActionsContainer').outerWidth();

      var left = itemWidth - parentWidth;
      k2btools.$(item).css({ left: -left });
    });
  };

  this.destroy = function () {
    this.CleanupMenuHide();
    this.CleanupMenu();
  };

  this.CleanupMenuHide = function () {
    k2btools.$('html').off('click', this.htmlClickCallback);
  };

  this.CleanupMenu = function () {
    k2btools.$('#K2BToolsMenu a').off('click', this.onMenuClick);
  };

  // Used to hide menus
  this.htmlClickCallback = function (e) {
    var uc = this;

    if (k2btools.$(e.target).closest('.Calendar, .daterangepicker, .gx-mask, .Table_ConditionalConfirm').length == 0 && !k2btools.$(e.target).is('body')) {
      k2btools.$('.K2BToolsTable_GridSettings:visible, .K2BToolsMyAccountTable:visible,  .ControlBeautify_CollapsableTable:visible').each(function (index, element) {
        var containerTable = k2btools.$(element).closest('.K2BToolsTable_GridSettingsContainer, .K2BToolsTable_MyAccountContainer, .ControlBeautify_ParentCollapsableTable');

        if (k2btools.ParentsCheck(e.target, 10) && k2btools.$(e.target).closest(containerTable).length < 1) {
          k2btools.$(element).hide();
        }
      });
    }

    if (k2btools.$('.K2BT_CommentsFloatingSection.K2BT_CommentsFloatingSectionOpen').length != 0) {
      if (k2btools.$(e.target).closest('.K2BT_CommentsFloatingSection.K2BT_CommentsFloatingSectionOpen').length == 0) {
        k2btools.$('.K2BT_CommentsFloatingSection.K2BT_CommentsFloatingSectionOpen').removeClass('K2BT_CommentsFloatingSectionOpen');
      }
    }
  };

  this.RefreshMenuHide = function () {
    k2btools.$('html').on('click', this.htmlClickCallback);
  };

  this.RefreshCheckboxes = function () {
    k2btools.checkboxRefresh();
  };

  this.insideActions = function (item) {
    return (
      k2btools
        .$(item)
        .parents(
          '#K2BTABLEACTIONSLEFTCONTAINER, #K2BTABLEACTIONSRIGHTCONTAINER, #K2BTABLEGRIDACTIONSLEFTCONTAINER, #K2BTABLEGRIDACTIONSRIGHTCONTAINER, #K2BTABLEACTIONSTOPCONTAINER, #K2BTABLEACTIONSBOTTOMCONTAINER, .Table_ComboActionsContainer, .Table_ActionsContainer, .K2BToolsTableCell_ActionContainer',
        ).length > 0
    );
  };

  this.selectIsInGrid = function (item) {
    return k2btools.$(item).closest('.gx-standard-grid').length >= 1;
  };
  this.RefreshSelects = function () {
    var uc = this;

    var selects = k2btools.$('select.K2BToolsEnhancedCombo');

    selects = selects.filter(function (i, item) {
      return gx.fn.isVisible(item, 0) && !uc.selectIsInGrid(item) && k2btools.$.inArray(item, k2btools.createdSelects) == -1;
    });

    if (selects.length != 0) {
      k2btools.$(selects).each(function (i, item) {
        if (uc.insideActions(item)) {
          k2btools.$(item).children("option[value=0], option[value='']").attr('disabled', 'disabled');
        }
      });

      k2btools.$(selects).removeClass().addClass('K2BToolsEnhancedCombo').selectpicker();

      k2btools.$(selects).each(function (i, item) {
        if (uc.insideActions(item)) {
          if (k2btools.$(item).find('[value!=0]').length == 0 || k2btools.$(item).find("[value!='']").length == 0) {
            k2btools.$(item).selectpicker('hide');
          } else {
            k2btools.$(item).selectpicker('show');
          }
        }
      });

      k2btools.$(selects).selectpicker('refresh');

      k2btools.$(selects).bind('DOMSubtreeModified', function () {
        k2btools.$(this).selectpicker('refresh');
      });
    }

    k2btools.$.merge(k2btools.createdSelects, selects);
    k2btools.selectRefresh();
  };

  this.RefreshTooltips = function () {
    k2btools.RefreshTooltips();
  };

  this.RefreshMenu = function () {
    var urlComps = window.location.pathname.split('/');
    var scriptName = urlComps[urlComps.length - 1];

    if (!this.IsPostBack) {
      var currentWPinMenu = false;
      k2btools.$('#K2BToolsMenu a').each(function (i, item) {
        if (k2btools.$(item).attr('href') == scriptName) {
          currentWPinMenu = true;
        }
      });

      if (currentWPinMenu) {
        k2btools.$('#K2BToolsMenu a').removeClass('activeOption');
        k2btools.$('#K2BToolsMenu a').each(function (i, item) {
          if (k2btools.$(item).attr('href') == scriptName) {
            k2btools.$(item).addClass('activeOption');
          }
        });
      }
    }

    k2btools.$('#K2BToolsMenu a').on('click', this.onMenuClick);
  };

  this.onMenuClick = function () {
    k2btools.$('#K2BToolsMenu a').removeClass('activeOption');
    k2btools.$(this).addClass('activeOption');
  };

  this.messages_handler_added = false;

  this.RefreshMessageHandling = function () {
    if (k2btools.$('style#k2btools-controlbeautify').length == 0) {
      $('<style>').attr('id', 'k2btools-controlbeautify').prop('type', 'text/css').html('.gx_ev{display:none;}').appendTo('head');
    }
    if (!this.IsPostBack) {
      var uc = this;
      if (!this.messages_handler_added) {
        this.messages_handler_added = true;

        toastr.options = {
          closeButton: true,
          debug: false,
          positionClass: 'toast-position',
          onclick: null,
          showDuration: '1000',
          hideDuration: '1000',
          timeOut: '8000',
          extendedTimeOut: '8000',
          showEasing: 'swing',
          hideEasing: 'linear',
          showMethod: 'fadeIn',
          hideMethod: 'fadeOut',
        };

        gx.fx.obs.addObserver('gx.onmessages', this, function (messages) {
          k2btools.$.each(messages, function (i, msgs) {
            k2btools.$.each(msgs, uc.showMessage(true));
          });
        });
      }

      k2btools.$('.gx_ev').each(function (i, item) {
        var pendingMessages = $(item)
          .children()
          .map(function () {
            if (k2btools.$(this).hasClass('gx-error-message')) return { text: k2btools.$(this).html(), type: 1 };
            else return { text: k2btools.$(this).html() };
          });
        k2btools.$.each(pendingMessages, uc.showMessage(false));
      });
    }
  };

  this.showMessage = function (encodeHTML) {
    return function (i, msg) {
      if (!(Object.prototype.toString.call(msg) === '[object Array]')) {
        // Refresh shown messages - take those generated in the last second
        k2btools.messagesShown = k2btools.$(k2btools.messagesShown).filter(function (index, element) {
          return new Date().getTime() - element.timestamp < 1000;
        });

        var message = htmlEncode(msg.text);
        if (!encodeHTML) message = msg.text;

        if (k2btools.showMessagesAssociatedWithAttributes || msg.att == '' || msg.att == undefined || msg.att == null || !gx.fn.isVisible(gx.fn.screen_CtrlRef(msg.att))) {
          if (
            k2btools.$(k2btools.messagesShown).filter(function (index, element) {
              return element.message.text === msg.text;
            }).length == 0
          ) {
            k2btools.messagesShown.push({ timestamp: new Date().getTime(), message: msg });
            if (msg.type === 1 || msg.value === 1) {
              toastr.error(message);
            } else {
              if (message.startsWith('K2BToolsMessage:error:')) {
                toastr.error(message.substr(22));
              } else if (message.startsWith('K2BToolsMessage:success:')) {
                toastr.success(message.substr(24));
              } else if (message.startsWith('K2BToolsMessage:warning:')) {
                toastr.warning(message.substr(24));
              } else if (message.startsWith('K2BToolsMessage:info:')) {
                toastr.info(message.substr(21));
              } else {
                toastr.success(message);
              }
            }
          }
        }
      }
    };
  };

  function htmlEncode(text) {
    return k2btools.$('<div />').text(text).html();
  }

  this.RefreshTagsCollectionFocus = function () {
    k2btools.$('.K2BToolsAttribute_BorderlessFilter').on('focusin', function () {
      k2btools.$(this).closest('.K2BToolsTable_FieldBorder').addClass('K2BToolsTable_FieldBorderFocus');
    });
    k2btools.$('.K2BToolsAttribute_BorderlessFilter').on('focusout', function () {
      k2btools.$(this).closest('.K2BToolsTable_FieldBorderFocus').removeClass('K2BToolsTable_FieldBorderFocus');
    });
  };

  this.RefreshOnImagePrompt = function () {
    k2btools.$('.K2BToolsOnImagePrompt').closest('A').addClass('btn btn-default');
    k2btools.$('.K2BToolsSection_PromptImageAndFieldContainer').on('focusin', function () {
      k2btools.$(this).addClass('K2BToolsSection_PromptImageAndFieldContainerFocus');
    });
    k2btools.$('.K2BToolsSection_PromptImageAndFieldContainer').on('focusout', function () {
      k2btools.$(this).removeClass('K2BToolsSection_PromptImageAndFieldContainerFocus');
    });
  };
}

/* Old checkall code */

function checkall(ev) {
  checkallgrid(ev, 'vSEL');
}

function getEventTarget(e) {
  e = e || window.event;
  return e.target || e.srcElement;
}

function checkallgrid(e, checksNamePart) {
  if (!e) var e = window.event;
  e.cancelBubble = true;
  if (e.stopPropagation) e.stopPropagation();

  var target = getEventTarget(e);

  for (var i = 0; i < document.MAINFORM.elements.length - 1; i++) {
    var c = document.MAINFORM.elements[i];

    if (c.type == 'checkbox' && c.name != 'allbox' && c.name.toUpperCase().indexOf(checksNamePart.toUpperCase()) >= 0) {
      if (c.checked != target.checked) {
        k2btools.$(c).trigger('click');
        k2btools.$(c).prop('checked', target.checked);
        k2btools.$(c).checkbox('refresh');
      }
    }
  }
}

/* End old checkall code */
