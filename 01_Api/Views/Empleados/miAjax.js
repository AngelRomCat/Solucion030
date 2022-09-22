function miAjax(param) {
	var miTabla ="";
	var miTabla01 = 
	"   <table>" +                                                             
	"        <thead>" +                                           
	"           <tr>" +          
	"               <th>EmployeeID</th>" +
	"               <th>FirstName</th>" +
	"               <th>LastName</th>" +
	"               <th>PhotoPath</th>" +
	"               <th>Detail</th>" +
	"           </tr>" +
	"        </thead>" +
	"        <tbody>";  
	var miTabla02 = "";
	var miTabla03 = 
	"       </tbody>" +
	"   </table>";
	
	var miTablaDetalle = "";
	const opciones = {
	method :'GET'
	}
	//[{"EmployeeID":"1","LastName":"Davolio","FirstName":"Nancy","Title":"Sales Representative","TitleOfCourtesy":"Ms.","BirthDate":"1948-12-08 00:00:00","HireDate":"1992-05-01 00:00:00","Address":"507 - 20th Ave. E.Apt. 2A","City":"Seattle","Region":"WA","PostalCode":"98122","Country":"USA","HomePhone":"(206) 555-9857","Extension":"5467","Photo":null,"Notes":"Education includes a BA in psychology from Colorado State University in 1970. She also completed \"The Art of the Cold Call.\" Nancy is a member of Toastmasters International.","ReportsTo":"2","PhotoPath":"http:\/\/accweb\/emmployees\/davolio.bmp","Salary":"2954.55"},
	if(param == null || param == 0){		
		fetch('https://localhost:44351/Api/Empleados',opciones)
		.then(respuesta => respuesta.json())
		.then(resultado =>{
			resultado.forEach(elemento => {            
				miTabla02 = miTabla02 + 
		"                    <tr>" +
		"                        <td>" + elemento.EmployeeID + "</td>" +
		"                        <td>" + elemento.FirstName + "</td>" +
		"                        <td>" + elemento.LastName + "</td>" +
		"                        <td>" + elemento.PhotoPath + "</td>" +
		"                        <td><input type=\"button\" value=\"Detalle\" onclick=\"miAjax(" + elemento.EmployeeID + ")\"></td>" +
		"                    </tr>";
			});
			miTabla = miTabla01 + miTabla02 + miTabla03;    
			document.getElementById("miTabla").innerHTML = miTabla;
		});
	} else {
		var miString = 'https://localhost:44351/Api/Empleados?id=' + param;
		fetch('https://localhost:44351/Api/Empleados?id=' + param,opciones)
		.then(respuesta => respuesta.json())
		.then(resultado =>{
			resultado.forEach(elemento => {            
				miTablaDetalle = miTablaDetalle +
		"   			   <table>" +  
		"                    <tr>" +
		"						 <th>EmployeeID</th>" +
		"                        <td>" + elemento.EmployeeID + "</td>" +
		"                    </tr>" +
		"                    <tr>" +
		"						 <th>FirstName</th>" +
		"                        <td>" + elemento.FirstName + "</td>" +
		"                    </tr>" +
		"                    <tr>" +
		"						 <th>LastName</th>" +
		"                        <td>" + elemento.LastName + "</td>" +
		"                    </tr>" +
		"                    <tr>" +
		"						 <th>PhotoPath</th>" +
		"                        <td>" + elemento.PhotoPath + "</td>" +
		"                    </tr>" +
		"                    <tr>" +
		"						 <th>Imagen</th>" +
		"                        <td><img src=\"https://tupelu.es/Ajax_y_Json/ajax_northwind_mysql/ajax_actual_fetch/detail/Images/empleado/" + elemento.EmployeeID + ".jpg\"></td>" +
		"                    </tr>" +
		"   			   </table>";
			});
			//miTabla = miTabla01 + miTabla02 + miTabla03;    
			document.getElementById("miTablaDetalle").innerHTML = miTablaDetalle;
		});
	}
}