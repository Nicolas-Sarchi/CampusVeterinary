# CampusVeterinary

## Uso

* ⚠️Se debe ejecutar el comando `dotnet ef database update --project ./Persistence/ --startup-project ./API/` para tener la base de datos actualizada

## Consultas

 ###  Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

 * Ruta : `http://localhost:5227/api/Vet/Specialization/Vascular-Surgeon`

![Captura de pantalla 2023-10-19 144546](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/b988b8de-d9c3-4ffd-937f-7984a12857d9)
![Captura de pantalla 2023-10-19 144905](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/447e1c09-91f4-4c47-aeaf-f5c4b4b11bdb)



 ###  Listar los medicamentos que pertenezcan a el laboratorio Genfar

Ruta : `http://localhost:5227/api/Medicine/Laboratory/Genfar`



![Captura de pantalla 2023-10-19 145235](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/310b75a4-e27d-4992-a70f-44f3b656d5ca)


![Captura de pantalla 2023-10-19 145309](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/b0953d50-df00-46c2-a849-f9a0b462d2cb)







 ###  Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

Ruta : `http://localhost:5227/api/Pet/Felines`
 


![Captura de pantalla 2023-10-19 145708](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/6d0be365-2abc-4422-ab93-636ccdbb7960)

![Captura de pantalla 2023-10-19 145734](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/ca9fa816-bff7-43a2-b0b4-05e79e69c378)







 ###  Listar los propietarios y sus mascotas.
 
Ruta : `http://localhost:5227/api/Owner`

![Captura de pantalla 2023-10-19 145905](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/519a4cc1-5d65-43b8-9e26-a26cd6680705)

![Captura de pantalla 2023-10-19 145932](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/a3c4be0a-f9cf-480d-b2fa-a84fddd4fa32)






 ###  Listar los medicamentos que tenga un precio de venta mayor a 50000.
 
Ruta : `http://localhost:5227/api/Medicine/GreaterThan5Thousand`
  


![Captura de pantalla 2023-10-19 150117](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/b2dcaefa-e700-4854-b71b-658c7d4e492a)


![Captura de pantalla 2023-10-19 150133](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/5d65e336-1802-4451-8234-7c1e62e012b7)



 ###  Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023
 
Ruta : `http://localhost:5227/api/Pet/Appointment/Vaccination`



![Captura de pantalla 2023-10-19 150500](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/74cc2518-92fc-4897-8fe1-db87e22c004a)


![Captura de pantalla 2023-10-19 150518](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/c563039e-c91d-4209-973d-fd0bf455b73b)






 ###  Listar todas las mascotas agrupadas por especie.
  
Ruta : `http://localhost:5227/api/Pet/BySpecies`




![Captura de pantalla 2023-10-19 150703](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/d490a435-6de3-43cd-904c-a775b33c7b43)



![Captura de pantalla 2023-10-19 150725](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/d9931908-da4f-4188-b3d0-ee227d3682c2)



 ###  Listar todos los movimientos de medicamentos y el valor total de cada movimiento.
 
Ruta : `http://localhost:5227/api/Medicine/Movements`


![Captura de pantalla 2023-10-19 150822](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/d40ad97e-706e-4dc7-80cb-cf8415b18fb3)



![Captura de pantalla 2023-10-19 150923](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/89b1de9a-9899-418c-90e7-be1fb89ec83c)



 ### Listar las mascotas que fueron atendidas por un determinado veterinario.
 
  * Ruta : `http://localhost:5227/api/Pet/AttendedBy?vetName=Pedro`
  * Nombres de los Veterinarios registrados en la base de datos : `Juan` , `Pedro`  



![Captura de pantalla 2023-10-19 151423](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/e40bac24-664e-47e2-944d-76c7da040755)

![Captura de pantalla 2023-10-19 151344](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/cefc1154-2f23-41aa-be9c-6f526f061a1e)



 ###  Listar los proveedores que me venden un determinado medicamento.
 
* Ruta: `http://localhost:5227/api/Supplier/Sells?medicineName=Amoxicilina`
* Nombres de los MEdicamentos registrados en la base de datos : `Amoxicilina` , `Gentamicina` , `Acetaminofen` 


![Captura de pantalla 2023-10-19 151736](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/7e19e722-22ea-4501-89b9-ffa4cb1f3cc0)


![Captura de pantalla 2023-10-19 152109](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/0d9122f4-91b2-4ee9-9527-96ab01e7640a)


 ###  Listar las mascotas y sus propietarios cuya raza sea Golden Retriver


Ruta : `http://localhost:5227/api/Pet/Breed/Golden-Retriever`




![Captura de pantalla 2023-10-19 152334](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/cea7d8d3-5e04-4b73-b06e-e0796dee0a04)



![Captura de pantalla 2023-10-19 152349](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/0bcac874-6920-43d4-851d-d2d0a9ae8608)



 ###  Listar la cantidad de mascotas que pertenecen a una raza

Ruta : `http://localhost:5227/api/Breed/petsNumber`

![image](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/049cb9b1-67ee-4d16-b7c5-7ea06423d0ed)

![image](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/d7be4cbb-c047-468a-a3bd-966292010cdd)

### JWT

`http://localhost:5227/api/User/refresh-token`
`http://localhost:5227/api/User/addrole`
`http://localhost:5227/api/User/token`
`http://localhost:5227/api/User/register`


