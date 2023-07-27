# using the iris dataset
library(datasets) # awakening the library called dataset
data = iris
head(data) # lets you see a handful of rows
View(data) # opening
nrow(data) #number of cases

class(data) # lets you examine the type of object

#
mean(data$Sepal.Length)

# finding out the number of species 
table(data$Species)

# Plotting
plot(x = data$Sepal.Length, y = data$Sepal.Width)


plot(x = data$Sepal.Length, y = data$Petal.Width)



