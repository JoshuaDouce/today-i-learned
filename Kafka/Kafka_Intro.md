# Kafka Introduction

Kafka is an open-source distributed event streaming platform. (Distributed Log)

Event streaming is the digital equivalent of the human body's central nervous system. It is the technological foundation for the 'always-on' world

Event streaming is
- Capturing data in real-time from event sources (databases, sensors, mobile devices, cloud services, and software applications in the form of streams of events)
- Storing these event streams durably for later retrieval
- Manipulating, processing, and reacting to the event streams in real-time as well as retrospectively
- Routing the event streams to different destination technologies
- Ensures a continuous flow and interpretation of data so that the right information is at the **right place, at the right time**.

## Use Cases
- Process payments and financial transactions in real-time.
- Track and monitor cars, trucks, fleets, and shipments in real-time
- Continuously capture and analyze sensor data from IoT devices
- To collect and immediately react to customer interactions
- Monitor patients in hospital care and predict changes in condition
- To connect, store, and make available data produced by different divisions of a company.
- To serve as the foundation for data platforms, event-driven architectures, and microservices.

## Kafka Capabiities
- To publish (write) and subscribe to (read) streams of events, including continuous import/export of your data from other systems.
- To store streams of events durably and reliably for as long as you want.
- To process streams of events as they occur or retrospectively.

## How does Kafka work?
- Kafka is a distributed system consisting of servers and clients that communicate via a high-performance TCP network protocol.
- Some of these servers form the storage layer, called the **Brokers**
- Other servers run **Kafka Connect** to continuously import and export data as event streams
- Kafka cluster is highly scalable and fault-tolerant
- **Clients:** They allow you to write distributed applications and microservices that read, write, and process streams of events in parallel, at scale, and in a fault-tolerant manner even in the case of network problems or machine failures.

## Main Concepts and Terminology
- An **event/record/message** records the fact that "something happened".
  - Key
  - Value
  - Timestamp
  - Metadata headers (optional)
- **Broker** a server that manages and distributes events, stores and serves data to consumers.
- **Producers** are those client applications that publish (write) events to Kafka
- **Consumers** are those that subscribe to (read and process) these events
  - Kafka provides various guarantees such as the ability to process events exactly-once.
- Events are organized and durably stored in **Topics**. Very simplified, a topic is similar to a folder in a filesystem, and the events are the files in that folder.
  - Topics in Kafka are always multi-producer and multi-subscriber: a topic can have zero, one, or many producers that write events to it, as well as zero, one, or many consumers that subscribe
  - Events in a topic can be read as often as needed
  - Define for how long Kafka should retain your events through a per-topic configuration setting
  - Kafka's performance is effectively constant with respect to data size, so storing data for a long time is perfectly fine.
  - **Topics** are **Partitioned**, meaning a topic is spread over a number of "buckets" located on different Kafka brokers.
  - Distributed placement of your data is very important for scalability because it allows client applications to both read and write the data from/to many brokers at the same time.
  - Events with the same event key (e.g., a customer or vehicle ID) are written to the same partition.
  - Kafka guarantees that any consumer of a given topic-partition will always read that partition's events in exactly the same order as they were written.
  - Every topic can be **replicated**, even across geo-regions or data-centers.

## Kafka APIs
-  **Admin API** to manage and inspect topics, brokers, and other Kafka objects.
-  **Producer API** to publish (write) a stream of events
-  **Consumer API** to subscribe to (read) one or more topics and to process the stream of events produced to them.
-  **Kafka Streams** API to implement stream processing applications and microservices.
-  **Kafka Connect API** to build and run reusable data import/export connectors that consume (read) or produce (write) streams of events from and to external systems. In practice, you typically don't need to implement your own connectors because the Kafka community already provides hundreds of ready-to-use connectors.