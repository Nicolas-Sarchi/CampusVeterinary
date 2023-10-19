# CampusVeterinary

## Consultas

 ### - Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

 * Ruta : `http://localhost:5227/api/Vet/Specialization/Vascular-Surgeon`

![Captura de pantalla 2023-10-19 144546](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/b988b8de-d9c3-4ffd-937f-7984a12857d9)
![Captura de pantalla 2023-10-19 144905](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/447e1c09-91f4-4c47-aeaf-f5c4b4b11bdb)



 ### - Listar los medicamentos que pertenezcan a el laboratorio Genfar

Ruta : `http://localhost:5227/api/Medicine/Laboratory/Genfar`



![Captura de pantalla 2023-10-19 145235](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/310b75a4-e27d-4992-a70f-44f3b656d5ca)


![Captura de pantalla 2023-10-19 145309](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/b0953d50-df00-46c2-a849-f9a0b462d2cb)







 ###  Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

Ruta : `http://localhost:5227/api/Pet/Felines`
 


![Captura de pantalla 2023-10-19 145708](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/6d0be365-2abc-4422-ab93-636ccdbb7960)

![Captura de pantalla 2023-10-19 145734](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/ca9fa816-bff7-43a2-b0b4-05e79e69c378)







 ### - Listar los propietarios y sus mascotas.
 
Ruta : `http://localhost:5227/api/Owner`

![Captura de pantalla 2023-10-19 145905](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/519a4cc1-5d65-43b8-9e26-a26cd6680705)

![Captura de pantalla 2023-10-19 145932](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/a3c4be0a-f9cf-480d-b2fa-a84fddd4fa32)






 ### - Listar los medicamentos que tenga un precio de venta mayor a 50000.
 
Ruta : `http://localhost:5227/api/Medicine/GreaterThan5Thousand`
  


![Captura de pantalla 2023-10-19 150117](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/b2dcaefa-e700-4854-b71b-658c7d4e492a)


![Captura de pantalla 2023-10-19 150133](https://github.com/Nicolas-Sarchi/CampusVeterinary/assets/131916765/5d65e336-1802-4451-8234-7c1e62e012b7)



 ### - Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023
 
Ruta : ``

![Captura de pantalla 2023-10-15 232649](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/85d89796-6ca5-425c-8640-9c5837a3f9c1)


![Captura de pantalla 2023-10-15 232628](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/6a5dd456-c61a-48e8-8728-29c27cdc827d)








 ### - Listar todas las mascotas agrupadas por especie.
  
Ruta : http://localhost:5143/api/especie/especie-mascota

![Captura de pantalla 2023-10-16 092807](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/03e4e081-c8e1-4659-8439-9f1bfc80591a)


![Captura de pantalla 2023-10-16 092736](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/8d880d3f-a6d3-4ce6-b7b6-644d58720b5d)








 ### - Listar todos los movimientos de medicamentos y el valor total de cada movimiento.
 
Ruta : http://localhost:5143/api/medicamento/movimientos

![Captura de pantalla 2023-10-16 114117](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/59511e05-7bee-40ad-bc00-2d7a7c94b97c)

![Captura de pantalla 2023-10-16 114100](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/3e7d0ae8-8e46-4b24-a320-645ccab6b23e)






 ### - Listar las mascotas que fueron atendidas por un determinado veterinario.
 
   Le pido que me envie el nombre del veterinario que deseas consultar las mascotas que ha atentido


Ruta : http://localhost:5143/api/mascota/Veterinario?nombre=Dr. Johnson     ------ Tienes que saber los nombres de los veterinarios que hay en la base de datos


 

![Captura de pantalla 2023-10-16 134000](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/0ef17c73-4473-47dd-87e2-7fafb8aced58)


![Captura de pantalla 2023-10-16 134021](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/d9a5227b-f73f-4bd2-8989-c378e60cbcdb)


![Captura de pantalla 2023-10-16 134007](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/4529af4e-1c44-4178-95fb-5f5d8e73f542)






 ### - Listar los proveedores que me venden un determinado medicamento.
 
   Le pido que me envie el nombre del medicamento que deseas consultar los proveedores que lo venden

Ruta : http://localhost:5143/api/proveedor/Medicamento?nombre=Ibuprofeno     ------ Tienes que saber los nombres de los medicamentos que hay en la base de datos



![Captura de pantalla 2023-10-16 135449](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/41cf7912-654a-448c-833c-d6a554e74c86)

![Captura de pantalla 2023-10-16 135516](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/d52257d7-fb95-4d6f-a510-11392cfd16db)

![Captura de pantalla 2023-10-16 135457](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/b5625f67-4809-478a-9201-0e67859c41d9)








 ### - Listar las mascotas y sus propietarios cuya raza sea Golden Retriver


Ruta : http://localhost:5143/api/mascota/Retriever 

![Captura de pantalla 2023-10-16 143053](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/145944be-fab9-4f22-a4b5-f4225197b15c)


![Captura de pantalla 2023-10-16 143026](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/3686caea-21ac-442d-a07d-92420d11b6f3)








 ### - Listar la cantidad de mascotas que pertenecen a una raza a una raza. Nota: Se debe mostrar una lista de las razas y la cantidad de mascotas que pertenecen a la raza.


Ruta : http://localhost:5143/api/mascota/razas 

![Captura de pantalla 2023-10-16 144358](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/8be88f67-5474-4423-93cc-2d73679246f8)


![Captura de pantalla 2023-10-16 144332](https://github.com/julianlpz69/VeterinariaCampus/assets/131847060/1f1f7b5f-10e2-4f95-b166-cd149eff6d2b)
