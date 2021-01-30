/*************
*  Routers	 *
*************/
var allRouters = [];

renderRoutersTable = function () {
	var innerHtml = "<tr><th>Tipo</th><th>Cantidad</th><th>Eliminar</th></tr>";
	var currentClass;
	for (var i = 0; i < allRouters.length; i++) {
		if (i % 2 == 0) {
			if (i == allRouters.length - 1) {
				currentClass = "td-even td-lastRow";
			} else {
				currentClass = "td-even";
			}
		} else {
			if (i == allRouters.length - 1) {
				currentClass = "td-odd td-lastRow";
			} else {
				currentClass = "td-odd";
			}
		}

		innerHtml += "<tr>";
		innerHtml += "<td class='td-firstCol " + currentClass + "'>";
		innerHtml += allRouters[i].Type;
		innerHtml += "</td>";
		innerHtml += "<td class='" + currentClass + "'>";
		innerHtml += allRouters[i].Quantity;
		innerHtml += "</td>";
		innerHtml += "<td class='td-lastCol " + currentClass + "' onclick='removeRouter(" + i + ")'>";
		innerHtml += "X";
		innerHtml += "</td>";
		innerHtml += "</tr>";
	}
	document.getElementById("routersTable").innerHTML = innerHtml;
}

removeRouter = function (index) {
	allRouters.splice(index, 1);
	renderRoutersTable();
}

/*************
*   Modal	 *
*************/
var modal = document.getElementById("myModal");
var addButton = document.getElementById("addButton");
var span = document.getElementsByClassName("close")[0];

closeModal = function () {
	document.getElementById("modalNumberOfRouters").value = 0;
	modal.style.display = "none";
}

addButton.onclick = function () {
	modal.style.display = "block";
}

span.onclick = function () {
	closeModal();
}

window.onclick = function (event) {
	if (event.target == modal) {
		closeModal();
	}
}

doAgregar = function () {
	allRouters.push({
		"Type": document.getElementById("modalRouterType").value,
		"Quantity": document.getElementById("modalNumberOfRouters").value
	});
	closeModal();
	renderRoutersTable();
}

/*************
* Generator	 *
*************/
downloadFile = function (data) {
	var fileName = (document.getElementById("inputName").value == "" ? "Networks" : document.getElementById("inputName").value) + ".zip";
	var textUrl = URL.createObjectURL(data);
	var element = document.createElement('a');
	element.setAttribute('href', textUrl);
	element.setAttribute('download', fileName);
	element.style.display = 'none';
	document.body.appendChild(element);
	element.click();
	document.body.removeChild(element);
}

doGenerate = function () {	
	fetch('http://localhost:58376/network/generator',
		{
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				NetworkName: document.getElementById("inputName").value == "" ? "Networks" : document.getElementById("inputName").value,
				Routers: allRouters
			})
		})
		.then((response) => {
			if (response.status != 200) {
				let errorMessage = "Error processing the request... (" + response.status + " " + response.statusText + ")";
				throw new Error(errorMessage);
			} else {
				return response.blob();
			}
		})
		.then((blob) => {
			downloadFile(blob);
		})
		.catch(error => {
			console.error(error);
		});	
}