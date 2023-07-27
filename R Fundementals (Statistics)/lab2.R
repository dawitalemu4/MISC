# calculating mean and variance 

# 1. generate a vector of score
score = c(1, 2, 3, 4, 5, 6)
score
# 2. calculate the mean 
sum_a = sum(score)
num_obs = length(score)
mean_a = sum_a/num_obs
mean_a

mean_b = mean(score)
mean_b

# 3. calculating the variance 
var_score = var(score)
var_score


## Problem set 1

# murder count 
murder = c(435, 352, 333, 338)
mean(murder)

var(murder)

sd(murder)

