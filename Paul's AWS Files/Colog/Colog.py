#cat Colog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,4 | sed 's/#//' | sed -e '1i\Date,Time,Orientation' > Colog.csv
import numpy as np
import matplotlib.pyplot as plt
from csv import reader
from dateutil import parser

with open('Colog.csv', 'r') as f:
    data = list(reader(f))

compass = [i[2] for i in data[1::]]
time = [parser.parse(i[1]) for i in data[1::]]

plt.plot(time, compass)
plt.title('Orientation over Time')
plt.xlabel('Time')
plt.ylabel('Orientation')

plt.legend(['Orientation'], loc=4)
plt.savefig('Colog.png')
