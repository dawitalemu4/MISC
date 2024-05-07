FROM php:8.3.4-apache

# Install mysqli
RUN docker-php-ext-install mysqli && docker-php-ext-enable mysqli
