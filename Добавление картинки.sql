UPDATE Recipes 
SET ImgRecipe = 
      (SELECT * FROM OPENROWSET(BULK N'C:\Users\pavilion\source\repos\planner\planner\images\��� � �������� ����.PNG', SINGLE_BLOB) AS image)
WHERE IdRecipe = 2