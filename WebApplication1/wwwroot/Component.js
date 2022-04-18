sap.ui.define([
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel",
	
	"sap/ui/Device"
], function (UIComponent, JSONModel,  Device) {
	"use strict";
	
	return UIComponent.extend("sap.ui.demo.walkthrough.Component", {
		metadata: {
			interfaces: ["sap.ui.core.IAsyncContentCreation"],
			manifest: "json"
		},
	
		init: function () {
			UIComponent.prototype.init.apply(this, arguments);
			var oDeviceModel = new JSONModel(Device);
			oDeviceModel.setDefaultBindingMode("OneWay");
			this.setModel(oDeviceModel, "device");
			this.getRouter().initialize();
		},
		
	});
});