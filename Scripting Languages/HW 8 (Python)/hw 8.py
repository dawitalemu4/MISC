class Circle:
    
    def __init__(self, radius):
        self.radius = radius
    
    @property
    def diameter(self):
        return self.radius * 2
    
    @property
    def area(self):
        return 3.14 * (self.radius ** 2)
    
c = Circle(5)
print(c.area)
