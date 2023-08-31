/**
 * @fileoverview gRPC-Web generated client stub for InstallerService
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!


/* eslint-disable */
// @ts-nocheck


import * as grpcWeb from 'grpc-web';

import InstallerService_pb from './InstallerService_pb';


export class InstallerServiceProtoClient {
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

  methodInfoOnGameInstallRequest = new grpcWeb.AbstractClientBase.MethodInfo(
    InstallerService_pb.InstallResponse,
    (request: InstallerService_pb.InstallRequest) => {
      return request.serializeBinary();
    },
    InstallerService_pb.InstallResponse.deserializeBinary
  );

  onGameInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null): Promise<InstallerService_pb.InstallResponse>;

  onGameInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void): grpcWeb.ClientReadableStream<InstallerService_pb.InstallResponse>;

  onGameInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/InstallerService.InstallerServiceProto/OnGameInstallRequest',
        request,
        metadata || {},
        this.methodInfoOnGameInstallRequest,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/InstallerService.InstallerServiceProto/OnGameInstallRequest',
    request,
    metadata || {},
    this.methodInfoOnGameInstallRequest);
  }

  methodInfoOnModInstallRequest = new grpcWeb.AbstractClientBase.MethodInfo(
    InstallerService_pb.InstallResponse,
    (request: InstallerService_pb.InstallRequest) => {
      return request.serializeBinary();
    },
    InstallerService_pb.InstallResponse.deserializeBinary
  );

  onModInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null): Promise<InstallerService_pb.InstallResponse>;

  onModInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void): grpcWeb.ClientReadableStream<InstallerService_pb.InstallResponse>;

  onModInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/InstallerService.InstallerServiceProto/OnModInstallRequest',
        request,
        metadata || {},
        this.methodInfoOnModInstallRequest,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/InstallerService.InstallerServiceProto/OnModInstallRequest',
    request,
    metadata || {},
    this.methodInfoOnModInstallRequest);
  }

  methodInfoOnCardInstallRequest = new grpcWeb.AbstractClientBase.MethodInfo(
    InstallerService_pb.InstallResponse,
    (request: InstallerService_pb.InstallRequest) => {
      return request.serializeBinary();
    },
    InstallerService_pb.InstallResponse.deserializeBinary
  );

  onCardInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null): Promise<InstallerService_pb.InstallResponse>;

  onCardInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void): grpcWeb.ClientReadableStream<InstallerService_pb.InstallResponse>;

  onCardInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/InstallerService.InstallerServiceProto/OnCardInstallRequest',
        request,
        metadata || {},
        this.methodInfoOnCardInstallRequest,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/InstallerService.InstallerServiceProto/OnCardInstallRequest',
    request,
    metadata || {},
    this.methodInfoOnCardInstallRequest);
  }

  methodInfoOnPluginInstallRequest = new grpcWeb.AbstractClientBase.MethodInfo(
    InstallerService_pb.InstallResponse,
    (request: InstallerService_pb.InstallRequest) => {
      return request.serializeBinary();
    },
    InstallerService_pb.InstallResponse.deserializeBinary
  );

  onPluginInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null): Promise<InstallerService_pb.InstallResponse>;

  onPluginInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void): grpcWeb.ClientReadableStream<InstallerService_pb.InstallResponse>;

  onPluginInstallRequest(
    request: InstallerService_pb.InstallRequest,
    metadata: grpcWeb.Metadata | null,
    callback?: (err: grpcWeb.Error,
               response: InstallerService_pb.InstallResponse) => void) {
    if (callback !== undefined) {
      return this.client_.rpcCall(
        this.hostname_ +
          '/InstallerService.InstallerServiceProto/OnPluginInstallRequest',
        request,
        metadata || {},
        this.methodInfoOnPluginInstallRequest,
        callback);
    }
    return this.client_.unaryCall(
    this.hostname_ +
      '/InstallerService.InstallerServiceProto/OnPluginInstallRequest',
    request,
    metadata || {},
    this.methodInfoOnPluginInstallRequest);
  }

}

