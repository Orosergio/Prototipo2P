CREATE DATABASE sic;
USE sic;
CREATE TABLE bodegas
(
	codigo_bodega VARCHAR(5) PRIMARY KEY,
    nombre_bodega VARCHAR(60),
    estatus_bodega VARCHAR(1)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE lineas
(
	codigo_linea INT PRIMARY KEY,
    nombre_linea VARCHAR(100),
    estado TINYINT
) ENGINE=INNODB DEFAULT CHARSET=latin1;
INSERT INTO lineas VALUES (1,'Linea A',true);
INSERT INTO lineas VALUES (2,'Linea B',true);
INSERT INTO lineas VALUES (3,'Linea C',true);

CREATE TABLE marcas
(
	codigo_marca INT PRIMARY KEY,
    nombre_marca VARCHAR(100),
    estado TINYINT
) ENGINE=INNODB DEFAULT CHARSET=latin1;
INSERT INTO marcas VALUES (1,'ZENTY',true);
INSERT INTO marcas VALUES (2,'MOCA',true);
INSERT INTO marcas VALUES (3,'CINTU',true);
INSERT INTO marcas VALUES (4,'ZANNYS',true);

CREATE TABLE productos
(
	codigo_producto INT PRIMARY KEY,
    nombre_producto VARCHAR(60),
    codigo_linea INT,
    codigo_marca INT,
    existencia_producto INT,
    estado TINYINT,
    FOREIGN KEY (codigo_linea) REFERENCES lineas(codigo_linea),
    FOREIGN KEY (codigo_marca) REFERENCES marcas(codigo_marca)
) ENGINE=INNODB DEFAULT CHARSET=latin1;
INSERT INTO productos VALUES(1,'Rueda',1,1,45,true);
INSERT INTO productos VALUES(2,'Zapato',2,2,45,true);
INSERT INTO productos VALUES(3,'Camisa',3,3,45,true);
INSERT INTO productos VALUES(4,'Mouse',1,3,45,true);
INSERT INTO productos VALUES(5,'Teclado',2,1,45,true);
INSERT INTO productos VALUES(6,'Pantalla',1,1,45,true);
INSERT INTO productos VALUES(7,'Lector',3,3,45,true); 
SELECT P.codigo_producto, P.nombre_producto, L.nombre_linea as Linea, M.nombre_marca as Marca, P.existencia_producto as existencia, P.estado as estado FROM 
productos P, lineas L, marcas M WHERE P.codigo_linea = L.codigo_linea AND P.codigo_marca = M.codigo_marca = P.codigo_marca;

CREATE TABLE existencias
(
	codigo_bodega VARCHAR(5),
    codigo_producto INT,
    saldo_existencia FLOAT(10,2),
    PRIMARY KEY (codigo_bodega, codigo_producto),
	FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE vendedores
(
	codigo_vendedor VARCHAR(5) PRIMARY KEY,
    nombre_vendedor VARCHAR(60),
    direccion_vendedor VARCHAR(60),
    telefono_vendedor VARCHAR(50),
    nit_vendedor VARCHAR(20),
    estatus_vendedor VARCHAR(1)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE clientes
(
	codigo_cliente VARCHAR(5) PRIMARY KEY,
    nombre_cliente VARCHAR(60),
    direccion_cliente VARCHAR(60),
    nit_cliente VARCHAR(20),
    telefono_cliente VARCHAR(50),
    codigo_vendedor VARCHAR(5),
    estatus_cliente VARCHAR(1),
    FOREIGN KEY (codigo_vendedor) REFERENCES vendedores(codigo_vendedor)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE proveedores
(
	codigo_proveedor VARCHAR(5) PRIMARY KEY,
    nombre_proveedor VARCHAR(60),
    direccion_proveedor VARCHAR(60),
    telefono_proveedor VARCHAR(50),
    nit_proveedor VARCHAR(50),
    estatus_proveedor VARCHAR(1)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE compras_encabezado
(
	documento_compraenca VARCHAR(10) PRIMARY KEY,
    codigo_proveedor VARCHAR(5),
    fecha_compraenca DATE,
	total_compraenca FLOAT(10,2),
    estatus_compraenca VARCHAR(1),
    FOREIGN KEY (codigo_proveedor) REFERENCES proveedores(codigo_proveedor)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE compras_detalle
(
	documento_compraenca VARCHAR(10),
    codigo_producto INT,
    cantidad_compradet FLOAT(10,2),
    costo_compradet FLOAT(10,2),
	codigo_bodega VARCHAR(5),
    PRIMARY KEY (documento_compraenca, codigo_producto),
    FOREIGN KEY (documento_compraenca) REFERENCES compras_encabezado(documento_compraenca),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto),
    FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE ventas_encabezado
(
	documento_ventaenca VARCHAR(10) PRIMARY KEY,
    codigo_cliente VARCHAR(5),
    fecha_ventaenca DATE,
    total_ventaenca FLOAT(10,2),
    estatus_ventaenca VARCHAR(1),
    FOREIGN KEY (codigo_cliente) REFERENCES clientes(codigo_cliente)
) ENGINE=INNODB DEFAULT CHARSET=latin1;

CREATE TABLE ventas_detalle
(
	documento_ventaenca VARCHAR(10),
    codigo_producto INT,
    cantidad_ventadet FLOAT(10,2),
    costo_ventadet FLOAT(10,2),
    precio_ventadet FLOAT(10,2),
    codigo_bodega VARCHAR(5),
    PRIMARY KEY (documento_ventaenca, codigo_producto),
    FOREIGN KEY (documento_ventaenca) REFERENCES ventas_encabezado(documento_ventaenca),
    FOREIGN KEY (codigo_producto) REFERENCES productos(codigo_producto),
    FOREIGN KEY (codigo_bodega) REFERENCES bodegas(codigo_bodega)
) ENGINE=INNODB DEFAULT CHARSET=latin1;