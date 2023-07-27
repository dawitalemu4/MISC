# Distribution of X bar
# 1st round of sampling
sample1 <- rnorm(1000, mean = 5.9, sd = 1.2)
mean(sample1)
hist(sample1)

# 2nd round of sampling 
sample2 <- rnorm(1000, mean = 5.9, sd = 1.2)
hist(sample2)
mean(sample2)

# repeating the process 1000
repli <- 1000
store <- rep(0, repli)

for(i in 1:length(store)){
  store[i] <- mean(rnorm(1000, mean = 5.9, sd = 1.2))
}

# distribution of sample mean 
hist(store)
mean(store)
(sd(store))^2

(1.2)^2/1000

## 2. We will pick the uniform distribution 
#visualzing a uniform distribution 
sampleU1 <- runif(1000, min = 4.8, max = 6.5)
hist(sampleU1)

# repeating the process 10000
repli <- 1000
store <- rep(0, repli)

for(i in 1:length(store)){
  store[i] <- mean(runif(100000, min = 4.8, max = 6.5))
}


hist(store)
mean(store)
sd(store)

#######################
# Birthweight example
#######################
repli <- 10000
store <- rep(0, repli)

for(i in 1:length(store)){
  store[i] <- mean(rnorm(36, mean = 3287, sd = sqrt(360000)))
}

# distribution of sample mean 
hist(store)
mean(store)
sd(store)


