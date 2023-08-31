/**
 * @fileoverview gRPC-Web generated client stub for TaskService
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!


/* eslint-disable */
// @ts-nocheck


import * as grpcWeb from 'grpc-web';

import * as google_protobuf_empty_pb from 'google-protobuf/google/protobuf/empty_pb';
import TaskService_pb from './TaskService_pb';


export class TaskServiceProtoClient {
  client_: grpcWeb.AbstractClientBase;
  hostname_: string;
  credentials_: null | { [index: string]: string; };
  options_: null | { [index: string]: any; };

  constructor (hostname: string,
               credentials?: null | { [index: string]: string; },
               options?: null | { [index: string]: any; }) {
    if (!options) options = {};
    if (!credentials) credentials = {};
    options['format'] = 'text';

    this.client_ = new grpcWeb.GrpcWebClientBase(options);
    this.hostname_ = hostname;
    this.credentials_ = credentials;
    this.options_ = options;
  }

  methodInfoOnList = new grpcWeb.AbstractClientBase.MethodInfo(
    TaskService_pb.TaskResponse,
    (request: google_protobuf_empty_pb.Empty) => {
      return request.serializeBinary();
    },
    TaskService_pb.TaskResponse.deserializeBinary
  );

  onList(
    request: google_protobuf_empty_pb.Empty,
    metadata?: grpcWeb.Metadata) {
    return this.client_.serverStreaming(
      this.hostname_ +
        '/TaskService.TaskServiceProto/OnList',
      request,
      metadata || {},
      this.methodInfoOnList);
  }

  methodInfoOnUpdate = new grpcWeb.AbstractClientBase.MethodInfo(
    TaskService_pb.TaskResponse,
    (request: google_protobuf_empty_pb.Empty) => {
      return request.serializeBinary();
    },
    TaskService_pb.TaskResponse.deserializeBinary
  );

  onUpdate(
    request: google_protobuf_empty_pb.Empty,
    metadata?: grpcWeb.Metadata) {
    return this.client_.serverStreaming(
      this.hostname_ +
        '/TaskService.TaskServiceProto/OnUpdate',
      request,
      metadata || {},
      this.methodInfoOnUpdate);
  }

}

