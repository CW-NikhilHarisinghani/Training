const grpc = require('@grpc/grpc-js');
const protoLoader = require('@grpc/proto-loader');

const packageDefinition = protoLoader.loadSync('greet.proto', {
  keepCase: true,
  longs: String,
  enums: String,
  defaults: true,
  oneofs: true,
});

const greetProto = grpc.loadPackageDefinition(packageDefinition).Greeter;
const client = new greetProto('localhost:5011', grpc.credentials.createInsecure());

client.SayHello({ name: 'Nikhil' }, (err, response) => {
  if (err) {
    console.error('Error:', err);
  } else {
    console.log('✅ Server Response:', response.message);
  }
});
