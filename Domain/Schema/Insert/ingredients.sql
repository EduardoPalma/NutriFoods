﻿SET SEARCH_PATH = "nutrifoods";

INSERT INTO ingredient (name, is_animal, contains_gluten, tertiary_group_id)
VALUES ('Sal', false, false, 23),
       ('Pimienta negra', false, false, 23),
       ('Aceite de oliva', false, false, 21),
       ('Cebolla', false, false, 7),
       ('Ajo', false, false, 7),
       ('Huevo', true, false, 14),
       ('Tomate', false, false, 4),
       ('Mantequilla', false, false, 18),
       ('Limón', false, false, 7),
       ('Zanahoria', false, false, 4),
       ('Cilantro', false, false, 3),
       ('Aceite', false, false, 21),
       ('Sal de mar', false, false, 23),
       ('Mayonesa', true, false, 24),
       ('Palta', false, false, 7),
       ('Albahaca', false, false, 3),
       ('Perejil', false, false, 3),
       ('Comino', false, false, 23),
       ('Pimiento rojo', false, false, 4),
       ('Crema', true, false, 13),
       ('Pure de papas', true, false, 6),
       ('Jugo de limón', false, false, 2),
       ('Oregano', false, false, 23),
       ('Queso parmesano', true, false, 20),
       ('Lechuga', false, false, 3),
       ('Queso crema', true, false, 20),
       ('Pimienta blanca', false, false, 23),
       ('Leche semidescremada', true, false, 18),
       ('Zapallo italiano', false, false, 3),
       ('Espinaca', false, false, 3),
       ('Champiñón', false, false, 7),
       ('Azúcar', false, false, 22),
       ('Mostaza', false, false, 23),
       ('Ají color', false, false, 23),
       ('Queso', true, false, 20),
       ('Berenjena', false, false, 1),
       ('Cebollín', false, false, 7),
       ('Ajo en polvo', false, false, 23),
       ('Tomate cherry', false, false, 1),
       ('Almendras', false, false, 15),
       ('Harina', false, true, 9),
       ('Tomillo', false, false, 23),
       ('Brócoli', false, false, 3),
       ('Choclo', false, false, 8),
       ('Espárrago', false, false, 3),
       ('Vinagre manzana', false, false, 24),
       ('Jengibre', false, false, 7),
       ('Apio', false, false, 3),
       ('Leche evaporada', true, false, 18),
       ('Papa', false, false, 6),
       ('Merkén', false, false, 23),
       ('Manzana', false, false, 1),
       ('Pechuga de pollo', true, false, 13),
       ('Vinagre', false, false, 24),
       ('Pimiento', false, false, 4),
       ('Garbanzo', false, false, 5),
       ('Atún', true, false, 10),
       ('Vainilla', false, false, 17),
       ('Aceite de coco', false, false, 21),
       ('Leche', true, false, 18),
       ('Queso mozzarella', true, false, 20),
       ('Salmón', true, false, 10),
       ('Aceite de palta', false, false, 21),
       ('Repollo', false, false, 3),
       ('Aceituna', false, false, 7),
       ('Arvejas', false, false, 5),
       ('Pepino', false, false, 3),
       ('Porotos verdes', false, false, 3),
       ('Aceituna negra', false, false, 7),
       ('Sésamo', false, false, 16),
       ('Linaza', false, false, 16),
       ('Polvo de hornear', false, false, 24),
       ('Canela', false, false, 23),
       ('Zapallo', false, false, 3),
       ('Curry', false, false, 23),
       ('Nuez moscada', false, false, 23),
       ('Queso cheddar', true, false, 20),
       ('Salsa de tomate', false, false, 24),
       ('Puerro', false, false, 3),
       ('Harina de almendra', false, false, 24),
       ('Pimiento verde', false, false, 3),
       ('Ciboulette', false, false, 7),
       ('Queso cabra', true, false, 20),
       ('Vinagre balsámico', false, false, 24),
       ('Laurel', false, false, 23),
       ('Cebolla morada', false, false, 7),
       ('Tahini', false, false, 16),
       ('Bicarbonato', false, false, 24),
       ('Vino blanco', false, false, 25),
       ('Cebolla en polvo', false, false, 23),
       ('Camarón', true, false, 11),
       ('Tocino', true, false, 12),
       ('Carne molida', true, false, 12),
       ('Betarraga', false, false, 7),
       ('Carne', true, false, 12),
       ('Nueces', false, false, 15),
       ('Alcaparra', false, false, 24),
       ('Alcachofa', false, false, 7),
       ('Lentejas', false, false, 5),
       ('Miel', false, false, 22),
       ('Menta', false, false, 23),
       ('Eneldo', false, false, 23),
       ('Salsa inglesa', false, false, 23),
       ('Naranja', false, false, 1),
       ('Sal rosada', false, false, 23),
       ('Arroz', false, false, 9),
       ('Vinagre blanco', false, false, 24),
       ('Levadura', false, false, 24),
       ('Pimiento amarillo', false, false, 7),
       ('Muslo de pollo', true, false, 13),
       ('Vinagre de vino blanco', false, false, 24),
       ('Cerdo', true, false, 12),
       ('Eritritol', false, false, 22),
       ('Harina de garbanzos', false, false, 24),
       ('Cuscús', false, false, 9),
       ('Ají', false, false, 7),
       ('Palmito', false, false, 7),
       ('Pan', false, true, 9),
       ('Anchoa', true, false, 10),
       ('Chalota', false, false, 7),
       ('Frutilla', false, false, 1),
       ('Poroto', false, false, 5),
       ('Mote', false, false, 9),
       ('Pasa', false, false, 1),
       ('Ají verde', false, false, 7),
       ('Miel de maple', false, false, 11),
       ('Maicena', false, false, 9),
       ('Jugo naranja', false, false, 2),
       ('Cacao en polvo', false, false, 24),
       ('Granada', false, false, 1),
       ('Tomate en tarro', false, false, 4),
       ('Estragón', false, false, 23),
       ('Poroto granado', false, false, 5),
       ('Ricotta', true, false, 20),
       ('Ají en polvo', false, false, 23),
       ('Vino tinto', false, false, 25),
       ('Ají rojo', false, false, 7),
       ('Jalapeño', false, false, 7),
       ('Leche de coco', false, false, 18),
       ('Piñón', false, false, 15),
       ('Chía', false, false, 16),
       ('Coliflor', false, false, 7),
       ('Jamón', true, false, 12),
       ('Pepinillo', false, false, 7),
       ('Amapola', false, false, 16),
       ('Crema de coco', false, false, 24),
       ('Harina de maíz', false, false, 9),
       ('Ulte', false, false, 26),
       ('Rúcula', false, false, 7),
       ('Paprika', false, false, 23),
       ('Maracuyá', false, false, 1),
       ('Aliño completo', false, false, 23),
       ('Escalopa de carne', true, false, 12),
       ('Salsa tomate', false, false, 24),
       ('Papas fritas', false, false, 24),
       ('Ketchup', false, false, 23),
       ('Piña', false, false, 1),
       ('Plátano', false, false, 1),
       ('Arándano', false, false, 1),
       ('Yogurt', false, false, 19),
       ('Cochayuyo', false, false, 26),
       ('Acelga', false, false, 3),
       ('Quinoa', false, false, 8),
       ('Maíz', false, false, 6),
       ('Salsa de ají', false, false, 23),
       ('Salsa de soya', false, false, 23),
       ('Caldo verduras', false, false, 23),
       ('Aquafaba', false, false, 5),
       ('Zapallo spaghetti', false, false, 7),
       ('Leche de almendra', false, false, 18),
       ('Cúrcuma', false, false, 23),
       ('Azúcar rubia', false, false, 22),
       ('Castañas', false, false, 15),
       ('Dátiles', false, false, 15),
       ('Tomate pera', false, false, 4),
       ('Cebolla chalota', false, false, 7),
       ('Papa camote', false, false, 6),
       ('Ciruela', false, false, 1),
       ('Damasco turco', false, false, 1),
       ('Higos', false, false, 1),
       ('Zapallo camote', false, false, 7),
       ('Zapallo butternut', false, false, 7),
       ('Cardamomo', false, false, 23),
       ('Avena', false, false, 9),
       ('Mermelada frambuesa', false, false, 24),
       ('Azafrán', false, false, 23),
       ('Lechuga escarola', false, false, 3),
       ('Tortilla', false, true, 9),
       ('Caldo de ave', true, false, 13),
       ('Habas', false, false, 5),
       ('Grano choclo', false, false, 6),
       ('Tapas de empanadas', true, false, 24),
       ('Pesto', false, false, 23),
       ('Tomate roma', false, false, 4),
       ('Carne vegetal', false, false, 24),
       ('Tortilla maíz', false, false, 9),
       ('Concentrado de tomate', false, false, 23),
       ('Crema acida', true, false, 18),
       ('Pan rallado', false, true, 9),
       ('Crema de leche', true, false, 18),
       ('Harina sin polvos de hornear', false, true, 9),
       ('Pure de zapallo', false, false, 24),
       ('Salvia deshidratada', false, false, 23),
       ('Almidón de maíz', false, false, 9),
       ('Clara de huevo', true, false, 14),
       ('Pasta de aji', false, false, 23),
       ('Salsa de tabasco', false, false, 23),
       ('Lomo de ternera', true, false, 12),
       ('Queso azul', true, false, 20),
       ('Yogurt griego', true, false, 19),
       ('Anato', false, false, 23),
       ('Pescado blanco', true, false, 10),
       ('Fiambre de pollo', true, false, 13),
       ('Salchicha', true, false, 12),
       ('Especias italianas', false, false, 23),
       ('Queso provoleta', true, false, 20),
       ('Chorizo', true, false, 12),
       ('Pasta de chipotle', false, false, 23),
       ('Romero', false, false, 23),
       ('Gelatina en polvo', true, false, 24),
       ('Harina de coco', false, false, 24),
       ('Bistec', true, false, 12),
       ('Caldo de carne', true, false, 23),
       ('Aceituna verde', false, false, 7),
       ('Jugo de almeja', true, false, 11),
       ('Pasta de curry', false, false, 23),
       ('Chocolate', true, false, 24),
       ('Semillas de zapallo', false, false, 16),
       ('Yema de huevo', true, false, 14),
       ('Mandarina', false, false, 1),
       ('Bacalao', true, false, 10),
       ('Rábano', false, false, 7),
       ('Chuleta de cerdo', true, false, 12),
       ('Uva', false, false, 1),
       ('Cava', false, false, 25), -- alcohol
       ('Pasta sin gluten', false, false, 9),
       ('Carne de cordero', true, false, 12),
       ('Rabo de ternera', true, false, 12),
       ('Cebolla perla', false, false, 7),
       ('Mostaza en grano', false, false, 23),
       ('Masa para pizza sin gluten', false, false, 9),
       ('Huevo de codorniz', true, false, 14),
       ('Cola de langostino', true, false, 11),
       ('Calamar', true, false, 11),
       ('Solomillo de cerdo', true, false, 12),
       ('Whisky', false, false, 25),
       ('Kanikama', true, false, 11),
       -- Nueva Lista --
       ('Leche condensada', true, false, 1),
       ('Manjar', true, false, 1),
       ('Cobertura chocolate semiamargo', true, false, 1),
       ('Filete', true, false, 1),
       ('Salsa caramelo', false, false, 1),
       ('Galletas', true, false, 1),
       ('Ostiones', true, false, 1),
       ('Berries', false, false, 1)


ON CONFLICT (name) DO NOTHING;

DELETE from recipe_quantity;
DELETE from recipe_measure;
DELETE from recipe;
DELETE from ingredient_measure;
SELECT count(*) FROM recipe_measure;
SELECT count(*) FROM recipe_quantity;

SELECT count(*) FROM recipe;
SELECT count(*) FROM ingredient_measure;

SELECT * from recipe_quantity WHERE recipe_id = 2457;
SELECT * from recipe_measure WHERE recipe_id = 2457;