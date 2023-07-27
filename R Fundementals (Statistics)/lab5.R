vals=rnorm(n=1000000, 
           mean=0, sd=1)

# creating a histogram
hist(vals, prob = "TRUE")
lines(density(vals), col = "red", lwd = 2)

# normal distribution with a fatter tail
vals2=rnorm(n=1000000, 
           mean=10, sd=6)

# creating a histogram
hist(vals2, prob = "TRUE")
lines(density(vals2), col = "red", lwd = 2)


# normal distribution with mean = 5 and sd = 3
vals3 = rnorm(n=1000000, 
            mean=5, sd=3)
# creating a histogram
hist(vals3, prob = "TRUE")
lines(density(vals3), col = "red", lwd = 2)

## converting val3 distribution to a standard normal 
vals4 = (vals3 - mean(vals3))/(sd(vals3))
hist(vals4, prob = "TRUE")
lines(density(vals4), col = "red", lwd = 2)
mean(vals4) ## should be close to 0
sd(vals4)  ## should be close to 1

#mean
mean(vals)
median(vals, prob = T)

vals