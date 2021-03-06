#cat Malog.txt | tr ' ' ',' | tr '/' '-' | cut -d ',' -f1,2,4,7,10 | sed 's/#//' | sed -e '1i\Date,Time,X,Y,Z' > Malog.csv
from matplotlib import pyplot, dates
from csv import reader
from dateutil import parser

with open('Malog.csv', 'r') as f:
    data = list(reader(f))

xaxis = [i[2] for i in data[1::]]
yaxis = [i[3] for i in data[1::]]
zaxis = [i[4] for i in data[1::]]
time = [parser.parse(i[1]) for i in data[1::]]

pyplot.plot(time, xaxis)
pyplot.plot(time, yaxis)
pyplot.plot(time, zaxis)
pyplot.title('Magnet over Time')
pyplot.xlabel('Time')
pyplot.ylabel('Megnetometer')
#pyplot.show()

pyplot.legend(['X Axis', 'Y Axis', 'Z Axis'], loc=4)

pyplot.savefig('Malog.png')
