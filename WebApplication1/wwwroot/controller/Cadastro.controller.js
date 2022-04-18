sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageToast",
	"sap/m/MessageBox",
	"sap/ui/model/resource/ResourceModel" 

], function (Controller, JSONModel, MessageToast, MessageBox, ResourceModel) {
	"use strict";
	return Controller.extend("sap.ui.demo.walkthrough.controller.Cadastro", {

		onInit: function () {
			this.getView().setModel(new JSONModel({
				nome: "",
				cpf: "",
				cep: "",
				rua: "",
				bairro: "",
				numero: "",
				cidade: "",
				email: "",
				estado:"",
				telefone: "",
			}), "cliente")
		},

		salvarNoBancoDeDados: function () {
			var cliente = this.getView().getModel("cliente");

			fetch('https://localhost:5001/api/Clientes/Inserir', {
				method: 'POST',
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(cliente.getData())
			})
				.then((resposta) => resposta.json())
				.then((data) => console.log(data))

		},

	});
 })